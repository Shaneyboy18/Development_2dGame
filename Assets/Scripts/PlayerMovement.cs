using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxis("Horizontal");
        

        transform.Translate(transform.right * dir * speed * Time.deltaTime);
        
    }
}
