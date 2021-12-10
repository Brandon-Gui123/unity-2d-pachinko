using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public string ballBasketTag;
    public GameManager gameManager;
    public ParticleSystem ballBasketPS;
    public AudioSource ballHitAudioSource;
    public AudioClip ballHitSound;
    public AudioSource ballBasketAudioSource;
    public AudioClip ballCollectedSound;

    [Min(0f)] public float ballHitMaxSoundSpeed;
    [Min(0f)] public float ballHitMinSoundSpeed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ballBasketTag))
        {
            Destroy(gameObject);
            gameManager.SetScoreCount(gameManager.score + 10);

            ballBasketPS.Play();
            ballBasketAudioSource.PlayOneShot(ballCollectedSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // scale volume according to velocity
        float ballSpeed = collision.otherRigidbody.velocity.magnitude;
        float ballHitSoundVolume = Mathf.InverseLerp(ballHitMinSoundSpeed, ballHitMaxSoundSpeed, ballSpeed);

        ballHitAudioSource.PlayOneShot(ballHitSound, ballHitSoundVolume);
    }
}
