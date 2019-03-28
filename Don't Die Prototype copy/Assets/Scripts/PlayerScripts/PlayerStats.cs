using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float defense;
    public float meeleAttack;
    public float rangedAttack;
    public float hungerBoost;
    public float thirstBoost;
    public float experience;

    private float experienceRequiredForNextLevel;
    private int playerLevel;


	void Awake () {
        experienceRequiredForNextLevel = 100;
        defense = 0;
        meeleAttack = 0;
        rangedAttack = 0;
        hungerBoost = 0;
        thirstBoost = 0;
        experience = 0;
        playerLevel = 1;
	}

    public void AddToStats(ItemScript item)
    {
        defense += item.GetDefenseBoost();
        meeleAttack += item.GetMeeleBoost();
        rangedAttack += item.GetRangedBoost();
        hungerBoost += item.GetHungerBoost();
        thirstBoost += item.GetThirstBoost();
    }
    public void SubtractFromStats(ItemScript item)
    {
        defense -= item.GetDefenseBoost();
        meeleAttack -= item.GetMeeleBoost();
        rangedAttack -= item.GetRangedBoost();
        hungerBoost -= item.GetHungerBoost();
        thirstBoost -= item.GetThirstBoost();
    }


}
