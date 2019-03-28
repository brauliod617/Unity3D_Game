using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodButton : MonoBehaviour
{

    public PlayerInvetory playerInvetory;
    private SpriteRenderer spriteRenderer;
    public Sprite originalSprite;
    public Sprite alteredSprite;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
    
    }



    private void OnMouseOver()
    {
        if(playerInvetory == null || spriteRenderer == null || originalSprite == null || alteredSprite == null)
        {
            print("Error in Food Button\n");
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            playerInvetory.ConsumeFruit();
            spriteRenderer.sprite = alteredSprite;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            spriteRenderer.sprite = originalSprite;
        }
    }
}