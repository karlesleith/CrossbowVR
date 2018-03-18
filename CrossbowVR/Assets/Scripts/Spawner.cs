using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour {

    // Game object to spawn reference
    public GameObject enemy;
    // Spawning variables
    public Vector3 spawnPoint;
    public float spawnTimes;
    public int startTimer;
    // Loop controller
    public bool stop;

    // Initialise values 
    private void Start()
    {
        stop = false;
        //StartCoroutine(Spawn());

    }

    public void SpawnGoblin() {
        stop = false;
        StartCoroutine(Spawn());
    }


    // Co - routine once started will keep spawning game objects referenced.
    IEnumerator Spawn()
    {
        //yield return new WaitForSeconds(startTimer);
        //while (!stop)
       // {
            Instantiate(enemy, transform.TransformPoint(spawnPoint), gameObject.transform.rotation);
            enemy.GetComponent<NavMeshAgent>().speed = Random.Range(0.1f,1.2f);
            //stop = true;
            yield return new WaitForSeconds(spawnTimes);
        //}
    }

}
