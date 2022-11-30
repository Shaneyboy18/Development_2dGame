using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public KeyCode shoot;
    private bool isShooting;

    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float speed, shootTimer;    


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(shoot) && !isShooting)
        {
            StartCoroutine(Shoot());            
        }
    }

    IEnumerator Shoot()
    {

        isShooting = true;
        GameObject newBullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.fixedDeltaTime, 0f);        

        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
        
    }
}
