using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRb = null;
    [SerializeField] SpriteRenderer mySpriteRenderer = null;
    [SerializeField] float speedForce = 10f;



    private void Awake()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void HandleMovement(int playerType)
    {
        var y = Input.GetAxisRaw("Vertical" + playerType.ToString()) * speedForce;
        var newVelocity = new Vector2(0, y) * Time.fixedDeltaTime;

        MyBounds cameraBounds = CameraManager.GetCameraBounds();
        ClampVelocityToCameraBounds(ref newVelocity);

        myRb.velocity = newVelocity;
    }

    private void ClampVelocityToCameraBounds(ref Vector2 newVelocity)
    {
        MyBounds cameraBounds = CameraManager.GetCameraBounds();
        var height = mySpriteRenderer.bounds.size.y;

        if (transform.position.y > cameraBounds.maxY - (height / 2) && newVelocity.y > 0)
        {
            newVelocity = Vector2.zero;
        }
        else if (transform.position.y < cameraBounds.minY + (height / 2) && newVelocity.y < 0)
        {
            newVelocity = Vector2.zero;
        }
    }
}