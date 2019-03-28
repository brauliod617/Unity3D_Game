using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCores : MonoBehaviour {

    private float playerHealth;
    private HungerEffects hungerEffects;
    private ThirstEffects thirstEffects;

    // Use this for initialization
    void Start () {
        playerHealth = 100;
        hungerEffects = GetComponent<HungerEffects>();
        thirstEffects = GetComponent<ThirstEffects>();
    }

	
	// Update is called once per frame
	void Update () {

        if(playerHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void ConsumeWater() { thirstEffects.ConsumeWater(); }//called from inventory
    public void ConsumeFood() { hungerEffects.ConsumeFood(); }//called from inventory
    public void DamageOverTime(int boost = 1) { playerHealth -= Time.deltaTime * boost; }
    public void ReceiveDamage(float damage) { playerHealth -= damage * Time.deltaTime; }
    public float GetPlayerHealth() { return playerHealth; }

    public float GetPlayerHunger() 
    {
        if (hungerEffects != null)
            return hungerEffects.GetPlayerHunger();
        else
            return 0;
    }

    public float GetPlayerThirst() 
    {
        if (thirstEffects != null)
            return thirstEffects.GetPlayerThirst();
        else
            return 0;
    }


}
