using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody;
    SpriteRenderer playerRenderer;
    Camera mainCamera;
    float hspeed = 10.0f;
    float jumpforce = 24.0f;
    [SerializeField] Transform groundCheck;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent <Rigidbody2D> ();
        playerRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;
        mainCamera.GetComponent<CameraFollowPlayer>().enabled = true;
    }

    private void FixedUpdate()
    {    
        if (isGrounded())
        {
            if (Mathf.Abs(rigidBody.velocity.x) <= 0)
                animator.Play("player");
            else
                animator.Play("playerRun");

            if (Input.GetKey("space"))
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpforce);
                animator.Play("playerJump");
            }
        }
        else
        {
            animator.Play("playerJump");
        }

        rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);

        if ( Input.GetKey("d"))
        {   
            rigidBody.velocity = new Vector2(hspeed , rigidBody.velocity.y);
            playerRenderer.flipX = false;
        }

        if (Input.GetKey("a") )
        {
            rigidBody.velocity = new Vector2(-1*hspeed , rigidBody.velocity.y);
            playerRenderer.flipX = true;
        }
      
    }


    private bool isGrounded()
    {
        return Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
    }
}
