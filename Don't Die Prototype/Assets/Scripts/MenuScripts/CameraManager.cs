using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {


    public GameObject mainGameObject;
    public GameObject menuGameObject;
    public GameObject inventoryGameObject;
    public GameObject statsGameObject;
    public GameObject itemViewGameObject;

    public PlayerController playerController;

    // Use this for initialization
    void Start () {

        ActivateMainGameObject();

    }
	
	// Update is called once per frame
	void Update () {

        if (mainGameObject == null || menuGameObject == null || inventoryGameObject == null ||
            statsGameObject == null || itemViewGameObject == null)
        {
            print("Error in CameraManager38\n");
            return;
        }

        if (Input.GetButtonDown("M"))
        {
            if (mainGameObject.activeSelf)
            {
                ActivateMenuGameObject();
                ActivateInventoryGameObject();
            }
            else
            {
                ActivateMainGameObject();
            }
        }
    }

    public void ActivateItemViewDetail()
    {
        if (mainGameObject.activeSelf)
        {
            mainGameObject.SetActive(false);
        }
        if (!menuGameObject.activeSelf)
        {
            menuGameObject.SetActive(true);
        }
        if (!itemViewGameObject.activeSelf)
        {
            if (inventoryGameObject.activeSelf)
            {
                inventoryGameObject.SetActive(false);
            }
            if (statsGameObject.activeSelf)
            {
                statsGameObject.SetActive(false);
            }
            itemViewGameObject.SetActive(true);
        }
    }

    public void ActivateStatsGameObject()
    {
        if(mainGameObject.activeSelf)
        {
            mainGameObject.SetActive(false);
        }
        if(!menuGameObject.activeSelf)
        {
            menuGameObject.SetActive(true);
        }
        if (!statsGameObject.activeSelf)
        {
            if (inventoryGameObject.activeSelf)
            {
                inventoryGameObject.SetActive(false);
            }
            if (itemViewGameObject.activeSelf)
            {
                itemViewGameObject.SetActive(false);
            }
            statsGameObject.SetActive(true);
        }
    }

    public void ActivateInventoryGameObject()
    {
        if (mainGameObject.activeSelf)
        {
            mainGameObject.SetActive(false);
        }
        if (!menuGameObject.activeSelf)
        {
            menuGameObject.SetActive(true);
        }

        if (!inventoryGameObject.activeSelf)
        {
            if (statsGameObject.activeSelf)
            {
                statsGameObject.SetActive(false);
            }
            if (itemViewGameObject.activeSelf)
            {
                itemViewGameObject.SetActive(false);
            }
            inventoryGameObject.SetActive(true);
        }
    }

    public void ActivateMenuGameObject()
    {
        if(!menuGameObject.activeSelf)
        {
            if (inventoryGameObject.activeSelf)
            {
                inventoryGameObject.SetActive(false);
            }
            if (statsGameObject.activeSelf)
            {
                statsGameObject.SetActive(false);
            }
            if (itemViewGameObject.activeSelf)
            {
                itemViewGameObject.SetActive(false);
            }
            menuGameObject.SetActive(true);
            playerController.SetMenuIsActive(true);
        }
        if(mainGameObject.activeSelf)
        {
            mainGameObject.SetActive(false);
        }
    }

    public void ActivateMainGameObject()
    {
        if (!mainGameObject.activeSelf)
        {
            if (inventoryGameObject.activeSelf)
            {
                inventoryGameObject.SetActive(false);
            }
            if (statsGameObject.activeSelf)
            {
                statsGameObject.SetActive(false);
            }
            if (itemViewGameObject.activeSelf)
            {
                itemViewGameObject.SetActive(false);
            }
            if (menuGameObject.activeSelf)
            {
                menuGameObject.SetActive(false);
            }
            mainGameObject.SetActive(true);
            playerController.SetMenuIsActive(false);
        }
    }



    /*

    public void ActivateMainCameraAndCanvas()
    {
        mainCamera.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(true);
        inventoryCanvas.gameObject.SetActive(false);
        inventoryCamera.gameObject.SetActive(false);
        statsCamera.gameObject.SetActive(false);
        statsCanvas.gameObject.SetActive(false);
        playerController.SetMenuIsActive(false);
    }
    public void ActivateInventoryCameraAndCanvas()
    {
        mainCamera.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(false);
        inventoryCamera.gameObject.SetActive(true);
        inventoryCanvas.gameObject.SetActive(true);
        statsCamera.gameObject.SetActive(false);
        statsCanvas.gameObject.SetActive(false);
        playerController.SetMenuIsActive(true);
    }
    public void ActivateStatsCameraAndCanvas()
    {
        mainCamera.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(false);
        inventoryCamera.gameObject.SetActive(false);
        inventoryCanvas.gameObject.SetActive(false);
        statsCamera.gameObject.SetActive(true);
        statsCanvas.gameObject.SetActive(true);
        playerController.SetMenuIsActive(true);
    }
    */
}
