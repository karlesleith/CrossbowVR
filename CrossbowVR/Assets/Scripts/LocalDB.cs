using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class LocalDB : MonoBehaviour {

    DataService ds;

    // Use this for initial

    void Awake () {

        ds = new DataService("crossbowVR.db");
        ds.CreateDB();

    }


    public void SaveScore(int score)
    {
        ds.CreateScore(score);
    }

    public int LoadMaxScore()
    {
        int maxScore = ds.GetMaxScore();
        return maxScore;
    }
}
