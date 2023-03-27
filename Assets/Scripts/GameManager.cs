using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private Animator movingText;
    

    public GameObject player;
    public int killedEnemies = 0;
    public GameObject roundObject;
    public bool endOfRound = false;
    public int enemyPerRound = 2;
    


    private int roundNumber = 1;
    private Text roundText;

    // Start is called before the first frame update
    void Start()
    {
        roundText = roundObject.GetComponentInChildren<Text>();
        StartCoroutine(roundTextDisplay());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(enemyPerRound);
        
        if(killedEnemies == enemyPerRound)
        {
            EndOfRound();
        }
          
    }

    void setEnemyPerRound()
    {
        enemyPerRound = roundNumber * 2;
    }


    IEnumerator roundTextDisplay()
    {
        setEnemyPerRound();
        roundText.text = "Round " + roundNumber.ToString();
        yield return new WaitForSeconds(2);
        movingText.Play("TextMove_1",0,0.0f);
        endOfRound = false;
      
    }

    void EndOfRound()
    {
        movingText.Play("TextMove_2", 0, 0.0f);
        if(movingText.IsInTransition(0))
        {
            StartCoroutine(waitSeconds(2));
        }
        endOfRound = true;
        roundNumber++;
        Spawner.enemyOnScreen = 0;
        killedEnemies = 0;
        StartCoroutine(roundTextDisplay());
    }

    IEnumerator waitSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}
