using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAttack : MonoBehaviour
{
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce;
    [SerializeField] private float timeBetweenShoot;
    [SerializeField] private float distanceFromEnemy;

    private float attackTimer;
    //private AgentScript agentScript;
    private PlayerHealth playerHealth;

    private void Start()
    {
        //agentScript = GetComponent<AgentScript>();
        playerHealth = GameManager.Instance.player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.isAlive == true)
        {
            attackTimer += Time.deltaTime;
            float distance = Vector3.Distance(transform.position, GameManager.Instance.player.transform.position);
            if (attackTimer >= timeBetweenShoot && distance <= distanceFromEnemy)
            {
                Shoot();
                attackTimer = 0f;
            }
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        
    }
}
