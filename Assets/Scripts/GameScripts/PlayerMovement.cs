using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    Animator animator;
    Rigidbody2D rigidBody;
    SpriteRenderer playerRenderer;
    Camera mainCamera;
    float hspeed = 10.0f;
    float jumpforce = 19.0f;
    [SerializeField] Transform groundCheck;
    public AudioSource playerJump;
    public AudioSource playerDie;
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
            if (joystick.Horizontal >= 0.02)
            {
                rigidBody.velocity = new Vector2(hspeed, rigidBody.velocity.y);
                playerRenderer.flipX = false;
            }

            if (joystick.Horizontal <= -0.02)
            {
                rigidBody.velocity = new Vector2(-1 * hspeed, rigidBody.velocity.y);
                playerRenderer.flipX = true;
            }

            if ( Input.touchCount > 0)
            {

                Touch touch = Input.GetTouch(0);
                                       

                if( touch.position.x > Screen.width/2  || Input.GetTouch(1).position.x > Screen.width/2)
                {   

                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpforce);
                    animator.Play("playerJump");
                    playerJump.Play();
                }
             
            }

        }
        else
        {
            animator.Play("playerJump");
            if (transform.position.y < -90)
            {
                playerDie.Play();
                transform.position = new Vector3(0, 0, 0);
            }
        }

        rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
      
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
