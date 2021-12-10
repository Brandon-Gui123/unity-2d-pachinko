using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    // Goal: Translate mouse click coordinates to positions
    //       where new coins will be created.

    // When mouse down, convert screen to world point via the help
    // of camera.
    // At that point, instantiate ball.

    public GameObject ball;
    public Collider2D ballPlacementArea;

    public GameManager gameManager;
    public ParticleSystem dropBallPS;
    public ParticleSystem ballBasketPS;

    public AudioSource ballCreatorAudioSource;
    public AudioClip ballCreationSound;

    public AudioSource ballHitAudioSource;
    public AudioClip ballHitSound;
    public AudioSource ballBasketAudioSource;
    public AudioClip ballCollectedSound;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameManager.balls <= 0)
            {
                return;
            }

            Vector3 creationPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            creationPosition.z = 0f;    // so that it is positioned in front of the camera

            if (ballPlacementArea.OverlapPoint(creationPosition))
            {
                GameObject ballInstance = Instantiate(ball, creationPosition, Quaternion.identity);
                
                var ballComponent = ballInstance.GetComponent<Ball>();
                ballComponent.gameManager = gameManager;
                ballComponent.ballBasketPS = ballBasketPS;
                ballComponent.ballHitAudioSource = ballHitAudioSource;
                ballComponent.ballHitSound = ballHitSound;
                ballComponent.ballBasketAudioSource = ballBasketAudioSource;
                ballComponent.ballCollectedSound = ballCollectedSound;

                gameManager.SetBallsCount(gameManager.balls - 1);

                var emitParams = new ParticleSystem.EmitParams();
                emitParams.position = creationPosition;

                dropBallPS.Emit(emitParams, 1);

                ballCreatorAudioSource.PlayOneShot(ballCreationSound);

                // to prevent balls from hogging too much resources
                Destroy(ballInstance, 10f);
            }
        }
    }
}
