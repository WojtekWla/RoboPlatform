using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int damage;

    private PlayerHealth playerHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameManager.Instance.player.GetComponent<PlayerHealth>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeHit(damage);
        }
        Destroy(gameObject);
    }
}
