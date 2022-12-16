using UnityEngine;

public class Bullet : MonoBehaviour
{



    // Start is called before the first frame update
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") != false)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
