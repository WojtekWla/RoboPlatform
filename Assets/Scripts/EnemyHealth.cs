using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    public HealthBar healthBar;
    public bool isAlive = true;


    // Start is called before the first frame update
    void Start()
    {
       
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            TakeHit(10);
            //print("Hit" + health);
        }
    }

    void TakeHit(int hit)
    {
        health -= hit;
        healthBar.SetHealth(health);
        if (health <=0 )
        {
            isAlive = false;
            GameManager.Instance.killedEnemies++;
            Destroy(gameObject);
        }
       
    }
}
