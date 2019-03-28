using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerEffects : MonoBehaviour {

    private float playerHunger;
    public float hungerTimer;//1
    private float privateHungerTimer;//1
    private float counter;
    private float foodComsumptionMultiplier;
    private PlayerCores playerCores;


    // Use this for initialization
    void Start () {
        foodComsumptionMultiplier = 10;
        counter = 5;
        playerHunger = 100;
        privateHungerTimer = hungerTimer;
        playerCores = GetComponent<PlayerCores>();
    }
	
	// Update is called once per frame
	void Update () {
        HungersEffect();
        RemoveFromHunger();
    }

    public void ConsumeFood()
    {
        if (playerHunger + foodComsumptionMultiplier <= 100)
            playerHunger += foodComsumptionMultiplier;
        else
            playerHunger = 100;
    }

    void RemoveFromHunger()
    {
        privateHungerTimer -= Time.deltaTime;
        if (privateHungerTimer <= 0)
        {
            playerHunger -= .4166f; //playerHunger will be 0 after 240 seconds/ half a day
            privateHungerTimer = hungerTimer;
        }
    }

    void AddToHunger(float amount)
    {
        if (amount + playerHunger > 100)
        {
            playerHunger = 100;
        }
        else
        {
            playerHunger += amount;
        }
    }

    void HungersEffect()
    {
        if (playerCores == null)
            return;

        if (playerHunger <= 50f)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                playerCores.DamageOverTime();
                //playerHealth -= Time.deltaTime;
                counter = 10;
            }
        }
        else if (playerHunger <= 25f)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                playerCores.DamageOverTime();
                //playerHealth -= Time.deltaTime;
                counter = 5;
            }
        }
        else if (playerHunger <= 0f)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                playerCores.DamageOverTime();
                //playerHealth -= Time.deltaTime;
                counter = 1;
            }
        }
    }

    public float GetPlayerHunger() { return playerHunger; }
}
