using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] PlayerManager myPlayerManager = null;
    [SerializeField] BallManager myBallManager = null;
    PowerUpSpawner myPowerUpSpawner = null;
    [SerializeField] int timeBetweenSpawn = 5;
    
    Vector2 myBallDefaultScale = Vector2.zero;
    Vector2 myPlayerDefaultScale = Vector2.zero;
    float myBallDefaultSpeed = 0;



    void Awake()
    {
        myPowerUpSpawner = gameObject.GetComponent<PowerUpSpawner>();
        StartCoroutine(StartSpawningPowerUps());
    }

    void Start()
    {
        myBallDefaultScale = myBallManager.gameObject.transform.localScale;
        myBallDefaultSpeed = myBallManager.GetComponent<BallMovement>().speed;
        myPlayerDefaultScale = myPlayerManager.gameObject.transform.localScale;
    }

    IEnumerator StartSpawningPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            myPowerUpSpawner.SpawnPowerUp();
        }
    }
    public void StartChangeBallSize(int time, int size)
    {
        StartCoroutine(ChangeBallSize(time, size));
    }

    IEnumerator ChangeBallSize(int time, int size)
    {
        myBallManager.gameObject.transform.localScale = new Vector2(size, size);
        yield return new WaitForSeconds(time);
        myBallManager.gameObject.transform.localScale = myBallDefaultScale;
    }

    public void StartChangeBallSpeed(int time, int speed)
    {
        StartCoroutine(ChangeBallSpeed(time, speed));
    }

    IEnumerator ChangeBallSpeed(int time, int speed)
    {
        int x = speed * (Random.Range(0, 2) * 2 - 1);
        int y = speed * (Random.Range(0, 2) * 2 - 1);

        var myBallRb = myBallManager.gameObject.GetComponent<Rigidbody2D>();
        
        myBallRb.velocity = new Vector2(x, y);
        yield return new WaitForSeconds(time);

        x = 5 * (Random.Range(0, 2) * 2 - 1);
        y = 5 * (Random.Range(0, 2) * 2 - 1);

        myBallRb.velocity = new Vector2(x, y);
    }

    public void StartChangePlayerSize(int time, int size, int playerType)
    {
        StartCoroutine(ChangePlayerSize(time, size, playerType));
    }

    IEnumerator ChangePlayerSize(int time, int size, int playerType)
    {
        var myPlayers = FindObjectsOfType<PlayerManager>();
        foreach (var myPlayer in myPlayers)
        {
            if ((int)myPlayer.myPlayerType == playerType)
            {
                myPlayer.gameObject.transform.localScale = new Vector2(size, size);
                yield return new WaitForSeconds(time);
                myPlayer.gameObject.transform.localScale = myPlayerDefaultScale;
            }
        }
    }
}
