using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    PowerUpManager myPowerUpManager = null;
    enum PowerUpTypes
    {
        BallSize,
        BallSpeed,
        PlayerSize,
    }



    void Awake()
    {
        myPowerUpManager = FindObjectOfType<PowerUpManager>();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) { return; }

        var powerUpTypesCount = Enum.GetNames(typeof(PowerUpTypes)).Length;
        var myPowerUpType = (PowerUpTypes)UnityEngine.Random.Range(0, powerUpTypesCount);

        switch(myPowerUpType)
        {
            case PowerUpTypes.BallSize:
            {
                myPowerUpManager.StartChangeBallSize(5, 2);
                break;
            }

            case PowerUpTypes.BallSpeed:
            {
                myPowerUpManager.StartChangeBallSpeed(5, 10);
                break;
            }
            case PowerUpTypes.PlayerSize:
            {
                myPowerUpManager.StartChangePlayerSize(5, 2, collision.gameObject.GetComponentInParent<BallMovement>().lastPlayerTouch);
                break;
            }
            default: { break; }
        }
        
        Destroy(gameObject);
    }
}
