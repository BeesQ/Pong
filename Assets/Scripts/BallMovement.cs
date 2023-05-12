using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D myRb = null;
    [SerializeField] SpriteRenderer mySpriteRenderer = null;
    [SerializeField] float speedForce = 10f;

    private void Awake()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
        // myRb.AddForce(new Vector2(speedForce, speedForce), ForceMode2D.Impulse);
        myRb.velocity = new Vector2(speedForce, speedForce);
    }

    public void HandleMovement(int playerType)
    {
        // var newVelocity = new Vector2(0, y) * Time.fixedDeltaTime;

    }

    private void Update()
    {
        // MyBounds cameraBounds = CameraManager.GetCameraBounds();
        // // Check if the ball is out of the camera boundaries
        // if (transform.position.x > cameraBounds.maxX || transform.position.x < cameraBounds.minX)
        // {
        //     // Reflect the ball's direction horizontally
        //     myRb.velocity = new Vector2(-myRb.velocity.x, myRb.velocity.y);
        // }
        // if (transform.position.y > cameraBounds.maxY || transform.position.y < cameraBounds.minY)
        // {
        //     // Reflect the ball's direction vertically
        //     myRb.velocity = new Vector2(myRb.velocity.x, -myRb.velocity.y);
        // }

        myRb.velocity = ClampVelocityToCameraBounds();
    }

    private Vector2 ClampVelocityToCameraBounds()
    {
        MyBounds cameraBounds = CameraManager.GetCameraBounds();
        var width = mySpriteRenderer.bounds.size.x;
        var height = mySpriteRenderer.bounds.size.y;

        if (transform.position.x > cameraBounds.maxX - (height / 2) && myRb.velocity.x > 0)
        {
            return new Vector2(-myRb.velocity.x, myRb.velocity.y);
        }
        else if (transform.position.x < cameraBounds.minX + (height / 2) && myRb.velocity.x < 0)
        {
            return new Vector2(-myRb.velocity.x, myRb.velocity.y);
        }

        else if (transform.position.y > cameraBounds.maxY - (height / 2) && myRb.velocity.y > 0)
        {
            return new Vector2(myRb.velocity.x, -myRb.velocity.y);
        }

        else if (transform.position.y < cameraBounds.minY + (height / 2) && myRb.velocity.y < 0)
        {
            return new Vector2(myRb.velocity.x, -myRb.velocity.y);
        }

        return myRb.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        var x = myRb.velocity.x;
        var y = myRb.velocity.y;



        if (contact.normal.y > 0.5f)
        {
            // Collision - Top
            myRb.velocity = new Vector2(x, -y);
        }
        else if (contact.normal.y < -0.5f)
        {
            // Collision - Bot
            myRb.velocity = new Vector2(x, -y);
        }
        else if (contact.normal.x < 0)
        {
            // Collision - Left
            myRb.velocity = new Vector2(-x, y);
        }
        else if (contact.normal.x > 0)
        {
            // Collision - Right
            myRb.velocity = new Vector2(-x, y);
        }
    }
}
