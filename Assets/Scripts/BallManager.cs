using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    BallMovement myBallMovement = null;

    void Awake()
    {
        myBallMovement = gameObject.GetComponent<BallMovement>();
    }

    void FixedUpdate()
    {
        myBallMovement.HandleMovement();
    }
}
