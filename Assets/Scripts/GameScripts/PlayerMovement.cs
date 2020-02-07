using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody;
    SpriteRenderer playerRenderer;
    public float hspeed = 10.0f;
    float jumpforce = 24.0f;
    bool isGrounded = true;

    [SerializeField]
    Transform groundCheck;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent <Rigidbody2D> ();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {    
            
        Debug.LogFormat("horizontal velocity = {0}",rigidBody.velocity.x);
        Debug.LogFormat("vertical velocity = {0}", rigidBody.velocity.y);
        Debug.LogFormat("isgrounded = {0}", isGrounded);

        if (Physics2D.Linecast(transform.position,groundCheck.position,  1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
            if( Mathf.Abs(rigidBody.velocity.x) <= 0)
                animator.Play("player");
        }
        else
        {
            animator.Play("playerJump");
            isGrounded = false;
        }
        rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        if ( Input.GetKey("d"))
        {   
            rigidBody.velocity = new Vector2(hspeed , rigidBody.velocity.y);
            if( isGrounded)
                animator.Play("playerRun");
            playerRenderer.flipX = false;
        }

        if (Input.GetKey("a") )
        {
            rigidBody.velocity = new Vector2(-1*hspeed , rigidBody.velocity.y);
            if(isGrounded)
                animator.Play("playerRun");
            playerRenderer.flipX = true;
        }

        if (isGrounded)
        {
            if (Mathf.Abs(rigidBody.velocity.x) <= 0)
                animator.Play("player");
        }

        if (Input.GetKey("space") && isGrounded )
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpforce);
             animator.Play("playerJump");
        }
    }
}
