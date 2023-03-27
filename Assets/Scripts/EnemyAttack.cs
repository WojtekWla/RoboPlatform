using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int attackPower = 10;
    [SerializeField] private float timeBetweenAttacks;
    
    
    private float attackTimer;
    private AgentScript agentScript;
    private PlayerHealth playerHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        agentScript = GetComponent<AgentScript>();
        playerHealth = GameManager.Instance.player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.isAlive == true)
        {
            float distance = Vector3.Distance(transform.position, GameManager.Instance.player.transform.position);

            attackTimer += Time.deltaTime;
            if (distance <= agentScript.Agent.stoppingDistance && attackTimer >= timeBetweenAttacks)
            {
                Attack();
                attackTimer = 0f;
            }
        }
    }

    void Attack()
    {
        print("Enemy is attacking");
        playerHealth.TakeHit(attackPower);
    }
}
