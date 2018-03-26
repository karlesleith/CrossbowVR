using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateHealthCtrl : MonoBehaviour {

    public int gateMaxHealth;
    public int gateCurrentHealth;

    public Slider HealthBar;
    

	// Use this for initialization
	void Start () {
        //Start the Game with Full health
        gateCurrentHealth = gateMaxHealth;

        HealthBar.maxValue = gateMaxHealth;
        HealthBar.value = HealthBar.maxValue; 
    }
	
	// Update is called once per frame
	void Update () {

        //To DO! If the GatesHealth Reaches 0
        //Stop the game and Show the User teh HighScore


        if (gateCurrentHealth < 0)
        {
            gateCurrentHealth = 0;
            Debug.Log("Game Over!");
        }
    
    }

    //Damage the Gate
   public void DamageGate(int damageToGive)
    {

        gateCurrentHealth -= damageToGive;

        HealthBar.value -= damageToGive;
    }

    public void HealthBonus(int HealthBonus)
    {
        Debug.Log("HealthBonus!");
        gateCurrentHealth += HealthBonus;
        HealthBar.value += HealthBonus;
        if(gateCurrentHealth > gateMaxHealth)
        {
            gateCurrentHealth = gateMaxHealth;
            HealthBar.value = HealthBar.maxValue;
        }
    }

    public void SetGateHealthBonus(int bonus)
    {
        gateCurrentHealth += bonus;
    }
}
