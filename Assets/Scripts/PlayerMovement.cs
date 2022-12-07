using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode quit;

    public float speed = 10;
    public float jumpForce = 5;
    public float groundDistance;
    public int airjumps = 1;
    private bool isJumping;
    private bool canJump;
    public bool facingRight;


    private Rigidbody2D rb2D;
    private int remainingJumps;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        remainingJumps = airjumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {
            rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
            flip();

           // GetComponent<Animator>().SetBool("Run Left", true);
        }
        else if (Input.GetKey(right))
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
            flip2();

            //GetComponent<Animator>().SetBool("Run Right", true);
            
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);

            /*GetComponent<Animator>().SetBool("Run Left", false);
            GetComponent<Animator>().SetBool("Run Right", false);*/
            
        }

        if (canJump == true ) 
        {
            remainingJumps = airjumps;
            canJump = false;
        }

        if (Input.GetKeyDown(jump) && !isJumping)
        {
            Jump();
        }
        quitGame();

        Debug.DrawRay(transform.position, -transform.up * groundDistance, Color.red);

    }

    private void Jump()
    {
        if(remainingJumps > 0)
        {
            Debug.Log("Before jump = " + remainingJumps);
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            remainingJumps--;
            Debug.Log("after jump = " + remainingJumps);
        }       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            canJump = true;
        }
    }

    void flip()
    {

        if (facingRight == true)
        {
            gameObject.transform.localScale = new Vector3(-3, 3, 3);
            
            facingRight = false;
        }

    }

    void flip2()
    {

        if (facingRight == false)
        {
            gameObject.transform.localScale = new Vector3(3, 3, 3);
            
            facingRight = true;
        }

    }

    void quitGame()
    {
       if (Input.GetKey(quit))
        {
            Application.Quit();
        }
    }
}
