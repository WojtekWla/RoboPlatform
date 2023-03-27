using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentScript : MonoBehaviour
{
    // Start is called before the first frame update


    
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationModifier;
    private NavMeshAgent agent;
    private EnemyHealth agentHealth;
    private Transform player;
    private PlayerHealth playerHealth;

    public NavMeshAgent Agent
    {
        get { return agent; }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agentHealth = GetComponent<EnemyHealth>();
        player = GameManager.Instance.player.transform;
        playerHealth = GameManager.Instance.player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if ( playerHealth.isAlive == true)
        {
            agent.SetDestination(player.position);
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }else
        {
            agent.enabled = false;
        }
    }
}
