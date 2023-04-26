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
        var newVelocity = new Vector2(0, y) * Time.fixedDeltaTime;

        MyBounds cameraBounds = CameraManager.GetCameraBounds();
        // transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, cameraBounds.minY, cameraBounds.maxY));
        if (transform.position.y > cameraBounds.maxY && newVelocity.y > 0)
        {
            newVelocity = Vector2.zero;
        }
        else if (transform.position.y < cameraBounds.minY && newVelocity.y < 0)
        {
            newVelocity = Vector2.zero;
        }
        myRb.velocity = newVelocity;
    }
}
