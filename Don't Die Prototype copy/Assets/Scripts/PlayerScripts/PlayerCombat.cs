using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {
    
    PlayerController player;
    public float playerMelleDamage;
    // Use this for initialization
	void Start () {
        player = this.GetComponentInParent<PlayerController>();
        playerMelleDamage = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy" && player != null && player.GetIsAttackting())
        {
            other.SendMessage("DamageSpider", playerMelleDamage, SendMessageOptions.DontRequireReceiver);
        }
    }
}

