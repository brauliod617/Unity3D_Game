using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring1Script : ItemScript {

    // Use this for initialization
    public PlayerController playerController;
    public PlayerInvetory playerInvetory;

	void Awake () {
        itemName = "Wooden Ring";
        itemType = "Ring";
        defenseBoost = 10;
        rangedBoost = 10;
        itemWeight = 0.1f;
        isDropable = true;
        isEquipable = true;
        sprite = GetComponent<SpriteRenderer>().sprite;
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (playerController == null || playerInvetory == null)
        {
            print("Error in Ring1Script\n");
            return;
        }

        if (other.gameObject.CompareTag("Player") && playerController.GetIsGathering() && !playerInvetory.GetIsFull())
        {
            playerInvetory.AddItem(this);
            gameObject.SetActive(false);
        }
    }

}
