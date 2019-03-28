using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterButton : MonoBehaviour {

    public  PlayerInvetory playerInvetory;
    private SpriteRenderer spriteRenderer;
    public Sprite originalSprite;
    public Sprite alteredSprite;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if(Input.GetButtonDown("Fire1") && playerInvetory != null && alteredSprite != null)
        {
            playerInvetory.ConsumeWater();
            spriteRenderer.sprite = alteredSprite;
        }
        if (Input.GetButtonUp("Fire1") && playerInvetory != null && originalSprite != null)
        {
            spriteRenderer.sprite = originalSprite;
        }
    }
}
