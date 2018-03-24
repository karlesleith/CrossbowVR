using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateHealthCtrl : MonoBehaviour {

    public Image healthBar;

	// Use this for initialization
	void Start () {
        healthBar.fillAmount = 1;
    }
	
	// Update is called once per frame
	void Update () {

        float hp = 250 * 100f / 250;
        hp /= 100f;
        healthBar.fillAmount = hp;
    }
}
