using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

    protected float defenseBoost;
    protected float meeleBoost;
    protected float rangedBoost;
    protected float hungerBoost;
    protected float thirstBoost;
    protected float itemWeight;
    protected string itemName;
    protected string itemType;
    protected bool isEquipable;
    protected bool isDropable;
    protected Sprite sprite;
    


    // Use this for initialization
    void Awake() {
        defenseBoost = 0;
        meeleBoost = 0;
        rangedBoost = 0;
        hungerBoost = 0;
        thirstBoost = 0;
        itemWeight = 0;
        itemName = "";
        itemType = "";
        isEquipable = false;
        isDropable = false;
        sprite = null;
    }

    public float GetDefenseBoost() { return defenseBoost; }
    public float GetMeeleBoost() { return meeleBoost; }
    public float GetRangedBoost() { return rangedBoost; }
    public float GetHungerBoost() { return hungerBoost; }
    public float GetThirstBoost() { return thirstBoost; }
    public float GetItemWeight() { return itemWeight; }
    public bool GetIsDropable() { return isDropable; }
    public bool GetIsEquipable() { return isEquipable; }
    public string GetItemName() { return itemName; }
    public string GetItemType() { return itemType; }
    public Sprite GetSprite() { return sprite; }


}
