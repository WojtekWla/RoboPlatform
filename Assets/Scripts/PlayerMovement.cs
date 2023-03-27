using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    private Rigidbody2D rb;
    private Vector2 movement;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GameManager.Instance.player.GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //rotation
        if (playerHealth.isAlive == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        }

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerHealth.isAlive == true)
        {
            rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
        }
    }
}
