using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    
    public bool isAlive = true;

    private int maxHealthvalue = 100;
    private int healthPoints;

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = maxHealthvalue;
        healthBar.SetMaxHealth(maxHealthvalue);
        
    }


    public void TakeHit(int hit)
    {
       
        healthPoints -= hit;
        healthBar.SetHealth(healthPoints);
        print("player Health" + healthPoints);
        if (healthPoints <= 0)
        {
           isAlive = false;
        }

        
    }

}
