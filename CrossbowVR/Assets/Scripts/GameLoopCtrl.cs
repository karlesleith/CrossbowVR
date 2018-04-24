using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoopCtrl : MonoBehaviour {

    public static GameLoopCtrl instance;

    public List<GameObject> spawners = new List<GameObject>();
    public GameObject announcement;
    public GameObject bonus;
    public GameObject deathScreen;

    public GameObject gate;

    private bool announcementActive;
    private int enemyNum = 5;
    private int round = 1;
    public int scoreCnt = 0;
  
    public Text roundText;


    public Text scoreText;
    public Text hiScore;

    private LocalDB db;

    void Awake()
    {
        instance = this;

    }

    // Use this for initialization
    void Start () {
        db = GetComponent<LocalDB>();
        StartCoroutine(Round(1, 5));
        scoreText.text = "Score:" + scoreCnt;
        hiScore.text = "HiScore: " + db.LoadMaxScore();
    }

    private void Update()
    {

        //Update The Score 
        scoreText.text = "Score:" + scoreCnt;
        if (announcementActive)
        {
            StartCoroutine(DisplayRound());            
        }
        roundText.text = "ROUND " + round;

        

        //GameOver

        if (gate.GetComponent<GateHealthCtrl>().gateCurrentHealth <= 0)
        {
            db.SaveScore(scoreCnt);
            SceneManager.LoadScene(0);
            deathScreen.SetActive(true);
            announcement.SetActive(false);

        }
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


    public void Score(int kp)
    {
        
        scoreCnt += kp;
        scoreText.text = "Score:" + scoreCnt;
    }

    public void LoadLevel()
    {

        Application.LoadLevel(Application.loadedLevel);
    }
}
