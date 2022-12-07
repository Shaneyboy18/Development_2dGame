using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public KeyCode shoot;
    private bool isShooting;

    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public float speed, shootTimer;       

    // Update is called once per frame
    void Update()
    {
        
        if (GetComponent<PlayerMovement>().facingRight == true)
        {
            if (Input.GetKeyDown(shoot) && !isShooting)
            {
                StartCoroutine(Shoot());

            }
        }
        if (GetComponent<PlayerMovement>().facingRight == false)
        {
            if (Input.GetKeyDown(shoot) && !isShooting)
            {
                StartCoroutine(reversedShoot());

            }
        }

        Destroy(GameObject.Find("Bullet(Clone)"), 3);
        Destroy(GameObject.Find("Bullet_switch(Clone)"), 3);

    }

    IEnumerator Shoot()
    {

        isShooting = true;
        GameObject newBullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.fixedDeltaTime, 0f);        

        yield return new WaitForSeconds(shootTimer);        
        isShooting = false;
        
    }

    IEnumerator reversedShoot()
    {

        isShooting = true;
        GameObject newBullet = Instantiate(bulletPrefab2, shootingPoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed * Time.fixedDeltaTime, 0f);

        yield return new WaitForSeconds(shootTimer);        
        isShooting = false;

    }    

}
