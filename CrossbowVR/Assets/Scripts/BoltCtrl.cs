﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltCtrl : MonoBehaviour {

    private float speed { get; set; }
    public Vector3 destination { get; set; }

    // Use this for initialization
    void Start () {
        speed = 6;
    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);
    }
}
