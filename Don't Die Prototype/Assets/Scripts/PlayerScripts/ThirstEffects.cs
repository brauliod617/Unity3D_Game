using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirstEffects : MonoBehaviour {

    private float playerThirst;
    public float thirstTimer;//1
    private float privateThirstTimer;//1
    private float counter;
    private float waterComsumptionMultiplier;
    public PlayerCores playerCores;

    // Use this for initialization
    void Start () {
        waterComsumptionMultiplier = 10;
        counter = 5;
        playerThirst = 100;
        privateThirstTimer = thirstTimer;
        playerCores = GetComponent<PlayerCores>();
    }
	
	// Update is called once per frame
	void Update () {
        RemoveFromThirst();
        ThirstsEffect();
    }

    public void ConsumeWater()
    {
        if (playerThirst + waterComsumptionMultiplier <= 100)
            playerThirst += waterComsumptionMultiplier;
        else
            playerThirst = 100;
    }

    void RemoveFromThirst()
    {
        privateThirstTimer -= Time.deltaTime;
        if (privateThirstTimer <= 0)
        {
            playerThirst -= .4166f;
            privateThirstTimer = thirstTimer;
        }
    }



    void AddToThirst(float amount)
    {
        if (amount + playerThirst > 100)
        {
            playerThirst = 100;
        }
        else
        {
            playerThirst += amount;
        }
    }
    void ThirstsEffect()
    {
        if (playerCores == null)
            return;

        if (playerThirst <= 50)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                playerCores.DamageOverTime();
                //playerHealth -= Time.deltaTime;
                counter = 10;
            }
        }
        else if (playerThirst <= 25)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                playerCores.DamageOverTime();
                //playerHealth -= Time.deltaTime;
                counter = 5;
            }
        }
        else if (playerThirst <= 0)
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

    public float GetPlayerThirst() { return playerThirst; }
}
