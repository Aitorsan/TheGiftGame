using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody;
    SpriteRenderer playerRenderer;
    Camera mainCamera;
    public Joystick joystick;

    float hspeed = 10.0f;
    float jumpforce = 19.0f;
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

            if( Input.touchCount > 0)
            {
               // if (Input.GetKey("space"))
                //{
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpforce);
                    animator.Play("playerJump");
               // }
            }
               
            

          
        }
        else
        {
            animator.Play("playerJump");
            if (transform.position.y < -100)
            {
                transform.position = new Vector3(0, 0, 0);
            }
        }

        rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        Debug.Log(string.Format("x:{0}", joystick.Horizontal));
        if ( joystick.Horizontal >= 0.02)
        {   
            rigidBody.velocity = new Vector2(hspeed , rigidBody.velocity.y);
            playerRenderer.flipX = false;
        }

        if (joystick.Horizontal <= -0.02)
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
