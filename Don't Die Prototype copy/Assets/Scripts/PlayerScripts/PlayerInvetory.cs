using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvetory : MonoBehaviour
{

    public InventoryItemDisplaysManager inventoryItemDisplaysManager;

    private float fruitAmount;
    private float woodAmount;
    private float waterAmount;
    private int itemLimit;
    private int itemCount;
    private float fruitAmountLimit;
    private float woodAmountLimit;
    private float waterAmountLimit;
    private bool isFull;
    private PlayerCores playerCores;
    private PlayerStats playerStats;
    private ItemScript playerRing1;
    private ItemScript playerRing2;
    private ItemScript playerAmulet1;
    private ItemScript playerAmulet2;
    

    /******************************************************Constructors*******************************************************/
    private void Awake()
    {
        itemLimit = 12;
        itemCount = 0;
        fruitAmountLimit = 10;
        woodAmountLimit = 10;
        waterAmountLimit = 10;
        isFull = false;
        playerCores = GetComponent<PlayerCores>();
        playerStats = GetComponent<PlayerStats>();
        playerRing1 = null;
        playerRing2 = null;
        playerAmulet1 = null;
        playerAmulet2 = null;
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("O"))
        {
            ConsumeWater();
        }
        if(Input.GetButtonDown("P"))
        {
            ConsumeFruit();
        }
    }

    public void AddItem(ItemScript item)
    { 
        if(playerCores == null || inventoryItemDisplaysManager == null)
        {
            print("Error in PlayerInvetory52\n");
            return;
        }
        if (!isFull)
        {
            inventoryItemDisplaysManager.AddItem(item);
            itemCount++;
        }
        if(itemCount >= itemLimit)
        {
            isFull = true;
        }
    }


    public void EquipItem(ItemScript item)
    { 
        if(playerStats == null)
        {
            print("Error in PlayerInvetory EquipItem 81\n");
            return;
        }
        if (item.GetItemName() == "Ring")
        {
            if (playerRing1 != null)
            {
                playerRing1 = item;
                playerStats.AddToStats(item);
                itemCount--;
            } 
            else if (playerRing2 != null)
            {
                playerRing2 = item;
                playerStats.AddToStats(item);
                itemCount--;
            }
        }
        else if (item.GetItemName() == "Amulet")
        {
            if (playerAmulet1 != null)
            {
                playerAmulet1 = item;
                playerStats.AddToStats(item);
                itemCount--;
            }
            else if (playerAmulet2 != null)
            {
                playerAmulet2 = item;
                playerStats.AddToStats(item);
                itemCount--;
            }
        }
    }


    /*******************************************************Getters*******************************************************/
    public float GetFruitAmount() { return this.fruitAmount; }
    public float GetFruitLimitAmount() { return this.fruitAmountLimit; }
    public float GetWoodAmount() { return this.woodAmount; }
    public float GetWoodLimitAmount() { return this.woodAmountLimit; }
    public float GetWaterAmount() { return this.waterAmount; }
    public float GetWaterAmountLimit() { return this.waterAmountLimit; }
    public bool GetIsFull() { return isFull; }
    public int GetItemLimit() { return itemLimit; }
    public int GetItemCount() { return itemCount; }

    /*******************************************************Setters*******************************************************/
    public void SetFruitAmount(float amount)
    {
        if (amount <= fruitAmountLimit)
            this.fruitAmount = amount;
    }

    public void SetWoodAmount(float amount)
    {
        if (amount <= woodAmountLimit)
            this.woodAmount = amount;
    }

    public void SetWaterAmount(float amount)
    {
        if (amount <= waterAmountLimit)
            this.waterAmount = amount;
    }

    public void SetFruitLimitAmount(float amount)
    {
        if (amount >= 0)
            this.fruitAmountLimit = amount;

        if (this.fruitAmount > amount)
            this.fruitAmount = amount;
    }

    public void SetWoodLimitAmount(float amount)
    {
        if (amount >= 0)
            this.woodAmountLimit = amount;

        if (this.woodAmount > amount)
            this.woodAmount = amount;
    }

    public void SetWaterLimitAmount(float amount)
    {
        if (amount >= 0)
            this.waterAmountLimit = amount;

        if (this.waterAmount > amount)
            this.waterAmount = amount;
    }

    /*******************************************************Modifiers*******************************************************/
    public void AddToFruitAmount(float amount)
    {
        if (amount >= 0)
        {
            if (this.fruitAmount + amount <= fruitAmountLimit)
                this.fruitAmount += amount;
            else
                this.fruitAmount = fruitAmountLimit;
        }
    }

    public void SubtractFromFruitAmount(int amount)
    { 
        if(amount >= 0 && this.fruitAmount >= amount)
        {
            this.fruitAmount -= amount;
        }

    }

    public void AddToWoodAmount(float amount)
    {
        if (amount >= 0)
        {
            if (this.woodAmount + amount <= woodAmountLimit )
                this.woodAmount += amount;
            else
                this.woodAmount = woodAmountLimit ;
        }
    }

    public void SubtractFromWoodAmount(float amount)
    {
        if (amount >= 0 && this.woodAmount >= amount)
        {
            this.woodAmount -= amount;
        }

    }
    public void AddToWaterAmount(float amount)
    {
        if (amount >= 0)
        {
            if (this.waterAmount + amount <= waterAmountLimit)
                this.waterAmount += amount;
            else
                this.waterAmount = waterAmountLimit;
        }
    }
    public void SubtractFromWaterAmount(float amount)
    {
        if (amount >= 0 && this.waterAmount >= amount)
        {
            this.waterAmount -= amount;
        }

    }
    /*****************************************************Consume Functions*********************************************************/

    public void ConsumeWater()
    {
        if (waterAmount > 0 && playerCores != null)
        {
            waterAmount--;
            playerCores.ConsumeWater();
        }
    }
    public void ConsumeFruit()
    {
        if (fruitAmount > 0 && playerCores != null)
        {   
            fruitAmount--;
            playerCores.ConsumeFood();
        }
    }
}
