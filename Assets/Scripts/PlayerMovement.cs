using UnityEngine;
using UnityEngine.SceneManagement;

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

    private int maxHealth = 25;
    public int currentHealth;

    private Rigidbody2D rb2D;
    private int remainingJumps;

    public AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        remainingJumps = airjumps;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {
            rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
            flip();            
        }
        else if (Input.GetKey(right))
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
            flip2();          

        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);           

        }

        if (canJump == true)
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
        if (remainingJumps > 0)
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(25);
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Taken Damage");

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            source.PlayOneShot(clip);
            //yield return new WaitForSeconds (2.0f);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
