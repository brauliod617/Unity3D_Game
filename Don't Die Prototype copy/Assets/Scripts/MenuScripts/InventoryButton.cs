 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    public Sprite originalSprite;
    public Sprite alteredSprite;
    public CameraManager cameraManager;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(spriteRenderer == null || alteredSprite == null || originalSprite == null ||
            cameraManager == null)
        {
            print("Error in InventoryButton\n");
            return;
        }


    }

    private void OnMouseOver()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            cameraManager.SendMessage("ActivateInventoryGameObject");
            //cameraManager.SendMessage("ActivateInventoryCameraAndCanvas");
            spriteRenderer.sprite = alteredSprite;
        }
        if(Input.GetButtonUp("Fire1"))
        {
            spriteRenderer.sprite = originalSprite;
        }
    }
}
