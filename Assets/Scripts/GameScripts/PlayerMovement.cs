using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody;
    SpriteRenderer renderer;
    public float hspeed = 10.0f;
    float jumpforce = 20.0f;
    bool isGrounded = true;

    [SerializeField]
    Transform groundCheck;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent <Rigidbody2D> ();
        renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
       // Debug.LogFormat("horizontal velocity = {0}",rigidBody.velocity.x);
        if (Physics2D.Linecast(transform.position,groundCheck.position,  1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
            if( rigidBody.velocity.x <= 0)
                animator.Play("player");
        }
        else
        {
            isGrounded = false;
        }

        if ( Input.GetKey("d"))
        {   
            rigidBody.velocity = new Vector2(hspeed , rigidBody.velocity.y);
            if( isGrounded)
                animator.Play("playerRun");
            renderer.flipX = false;
        }
         if (Input.GetKey("a") )
        {
            rigidBody.velocity = new Vector2(-1*hspeed , rigidBody.velocity.y);
            if(isGrounded)
                animator.Play("playerRun");
            renderer.flipX = true;
        }

        if (Input.GetKey("space") && isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpforce);
            animator.Play("playerJump");
        }
    }
}
