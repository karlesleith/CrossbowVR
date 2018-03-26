using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporterCtrl : MonoBehaviour {

    private GameObject wayPoint;
    public float speed;


    void Start()
    {
        wayPoint = this.gameObject;

    }

    
    void Update()
    {
        //Spining Pointer to add more life
        wayPoint.transform.Rotate(Vector3.back, speed * Time.deltaTime);



    }
}
