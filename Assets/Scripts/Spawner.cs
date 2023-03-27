using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static int enemyOnScreen;

    [SerializeField] private GameObject[] enemiesArray;
    //[SerializeField] private int maxEnemiesOnScreen = 2;
    
    private float spawningDelay = 2f;
    //private int enemyDuringWave = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        
        if (enemyOnScreen < GameManager.Instance.enemyPerRound)
        {           
            int randomEnemy = Random.Range(0, enemiesArray.Length);
            yield return new WaitForSeconds(spawningDelay);
            GameObject enemy = Instantiate(enemiesArray[randomEnemy], transform.position, Quaternion.identity);
            enemyOnScreen++;
      
        }
        yield return null;
        StartCoroutine(Spawn());
    }

}
