using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

}
