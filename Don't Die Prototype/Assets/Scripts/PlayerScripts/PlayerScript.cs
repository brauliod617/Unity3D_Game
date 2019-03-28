using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private float health;
    private float defense;
    private float rangedAttack;
    private float hungerBoost;
    private float thirstBoost;
    private float experience;
    private float experienceRequiredForLevelUp;

    void Awake () 
    {
        health = 100;
        defense = 0;
        rangedAttack = 0;
        hungerBoost = 0;
        thirstBoost = 0;
        experience = 0;
        experienceRequiredForLevelUp = 1000;
	}
	
}
