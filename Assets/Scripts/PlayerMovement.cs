using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 5;
    public float groundDistance;
    public int airjumps = 1;

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
        float dir = Input.GetAxis("Horizontal");        

        transform.Translate(transform.right * dir * speed * Time.deltaTime);
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, groundDistance);

        if (hit.collider != null) 
        {
            remainingJumps = airjumps;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

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
}
