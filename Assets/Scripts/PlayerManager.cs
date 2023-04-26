using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public enum PlayerType { One, Two };
    [SerializeField] private PlayerType player;
    PlayerMovement myPlayerMovement = null;

    void Awake()
    {
        myPlayerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    void FixedUpdate()
    {
        myPlayerMovement.HandleMovement();
    }
}
