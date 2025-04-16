using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.collider.GetComponent<Ball>();

        if (ball != null)
            ball.IsCanJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Ball ball = collision.collider.GetComponent<Ball>();

        if (ball != null)
            ball.IsCanJump = false;
    }
}
