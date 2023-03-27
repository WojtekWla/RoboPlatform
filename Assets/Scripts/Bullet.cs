using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletPower = 10f;
   
    private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag != "Player")
        //{
            Destroy(gameObject);
        //}
        
    }

}
