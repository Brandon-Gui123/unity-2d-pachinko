using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBasket : MonoBehaviour
{
    // Goal: Make the basket move to the left,
    //       then to the right.

    public float leftMostLimit;
    public float rightMostLimit;
    public float speed;
    private bool isGoingToRight;

    private void FixedUpdate()
    {
        if (transform.position.x <= leftMostLimit)
        {
            // gone too far left, so we have to come back to the right
            isGoingToRight = true;
        }
        else if (transform.position.x >= rightMostLimit)
        {
            // gone too far right, so we have to come back to the left
            isGoingToRight = false;
        }

        if (isGoingToRight)
        {
            transform.Translate(speed * Time.fixedDeltaTime, 0f, 0f);
        }
        else
        {
            transform.Translate(-speed * Time.fixedDeltaTime, 0f, 0f);
        }
    }
}
