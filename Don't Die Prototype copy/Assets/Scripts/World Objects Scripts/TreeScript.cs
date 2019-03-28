using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {

    // Use this for initialization
    public int woodAmount;
    public float waitTime;
    private float waitCounter;
    private bool giveWood;

    void Start() {
        waitCounter = 0;
        giveWood = false;
    }

    // Update is called once per frame
    void Update() {

        if (woodAmount <= 0)
            Destroy(this.gameObject);

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")//if player near fruit
        {
            if(other.gameObject.GetComponent<PlayerController>().GetIsGathering())//and gathering
            {
                //fruit will be given once every 3 seconds
                if (giveWood)//if its time to give fruit
                {
                    other.gameObject.SendMessage("ReceiveWood", 1);//send message to player controller to add 1 fruit to invetory
                    giveWood = false;//set it to false to reset wait time
                    woodAmount--;
                }
                waitCounter += Time.deltaTime; // increment waitcounter by time since last frame
                if(waitCounter >= waitTime) //if waitcounter passed waittime
                {
                    waitCounter = 0; //reset waitcounter
                    giveWood = true; //say it is now time to give fruit
                }
            }
        }
    }
}
