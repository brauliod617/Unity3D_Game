using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDScript : MonoBehaviour {

    PlayerInvetory playerInventory;
    PlayerCores playerCores;


    public Text healthText;
    public Text hungerText;
    public Text thirstText;
    public Text fruitText;
    public Text woodText;
    public Text waterText;

    public Text healthTextInv;
    public Text hungerTextInv;
    public Text thirstTextInv;
  

    // Use this for initialization
    void Start () {
        playerInventory = GetComponent<PlayerInvetory>();
        playerCores = GetComponent<PlayerCores>();
        updateText();
	}
	
	// Update is called once per frame
	void Update () {
        updateText();
	}

    void updateText()
    {
        if (!(healthText == null || hungerText == null || thirstText == null || fruitText == null || woodText == null ||
              healthTextInv == null || hungerTextInv == null || thirstTextInv == null))
        {
            healthText.text = "Health: " + Mathf.Floor(playerCores.GetPlayerHealth()).ToString();
            hungerText.text = "Hunger: " + Mathf.Floor(playerCores.GetPlayerHunger()).ToString();
            thirstText.text = "Thirst: " + Mathf.Floor(playerCores.GetPlayerThirst()).ToString();
            healthTextInv.text = "Health: " + Mathf.Floor(playerCores.GetPlayerHealth()).ToString();
            hungerTextInv.text = "Hunger: " + Mathf.Floor(playerCores.GetPlayerHunger()).ToString();
            thirstTextInv.text = "Thirst: " + Mathf.Floor(playerCores.GetPlayerThirst()).ToString();    
            woodText.text = "Wood: " + playerInventory.GetWoodAmount().ToString();
            fruitText.text = "Fruit: " + playerInventory.GetFruitAmount().ToString();
            waterText.text = "Water: " + playerInventory.GetWaterAmount().ToString();
        }
    }
}
