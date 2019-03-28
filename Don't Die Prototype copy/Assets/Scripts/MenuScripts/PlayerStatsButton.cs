using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsButton : MonoBehaviour {

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
		
	}

    private void OnMouseOver()
    {
        if (spriteRenderer == null || originalSprite == null || alteredSprite == null ||
            cameraManager == null)
        {
            print("Error in PlayerStatsButton\n");
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            spriteRenderer.sprite = alteredSprite;
            cameraManager.SendMessage("ActivateStatsGameObject");
            //cameraManager.SendMessage("ActivateStatsCameraAndCanvas");
        }
        if (Input.GetButtonUp("Fire1"))
        {
            spriteRenderer.sprite = originalSprite;
        }
    }
}
