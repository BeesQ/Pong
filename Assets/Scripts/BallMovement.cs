using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D myRb = null;
    [SerializeField] SpriteRenderer mySpriteRenderer = null;
    [SerializeField] float speed = 10f;

    private void Awake()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
        myRb.velocity = new Vector2(speed, speed);
    }

    public void HandleMovement()
    {
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
