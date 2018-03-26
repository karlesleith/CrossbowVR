using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoopCtrl : MonoBehaviour {

    public static GameLoopCtrl instance;

    public List<GameObject> spawners = new List<GameObject>();
    public GameObject announcement;
    public GameObject bonus;

    public GameObject gate;

    private bool announcementActive;
    private int enemyNum = 5;
    private int round = 1;
    private int scoreCnt = 10;
    public int scoreSpeed;
    

    public Text roundText;


    public Text scoreText;

    void Awake()
    {
        instance = this;

    }

    // Use this for initialization
    void Start () {
        StartCoroutine(Round(1, 5));
    }

    private void Update()
    {
        if (announcementActive)
        {
            StartCoroutine(DisplayRound());            
        }
        roundText.text = "ROUND " + round;

        scoreCnt += scoreSpeed;
        scoreText.text = "Score:" + scoreCnt;
    }


    IEnumerator Round(int round, int enemyNum)
    {
        Debug.Log("Round: " + round + ". Enemies: " + enemyNum);
        this.announcementActive = true;
        gate.GetComponent<GateHealthCtrl>().HealthBonus(25);
        this.round = round;
        this.enemyNum = enemyNum;
        while (this.enemyNum > 0)
        {
            for (int i = 0; i < 3; i++)
            {
                spawners[i].GetComponent<Spawner>().SpawnGoblin();
                this.enemyNum--;
                yield return new WaitForSeconds(0.5f);
            }
            
            yield return new WaitForSeconds(3);
            this.announcementActive = false;
        }
        yield return new WaitForSeconds(10);
        Debug.Log("Round ended!");
        StartCoroutine(Round((this.round+1), this.round*5));
    }


    IEnumerator DisplayRound()
    {
        announcement.SetActive(true);
        bonus.SetActive(true);
        yield return new WaitForSeconds(5);
        announcement.SetActive(false);
        bonus.SetActive(false);
    }
}
