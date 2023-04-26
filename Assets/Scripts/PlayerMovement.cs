using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRb = null;
    [SerializeField] float speedForce = 10f;

    private void Awake()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
    }
    public void HandleMovement()
    {
        var y = Input.GetAxisRaw("Vertical") * speedForce;
        myRb.velocity = new Vector2(0, y) * Time.fixedDeltaTime;
    }
}
