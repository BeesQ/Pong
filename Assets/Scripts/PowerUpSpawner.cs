using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] GameObject myPowerUp = null;
    Vector2 powerUpSpawnerPosition = Vector2.zero;



    public void SpawnPowerUp()
    {
        var x = Random.Range(-5f, 5f);
        var y = Random.Range(-3.5f, 3.5f);
        powerUpSpawnerPosition = new Vector2(x, y);

        Instantiate(myPowerUp, powerUpSpawnerPosition, Quaternion.identity);
    }
}
