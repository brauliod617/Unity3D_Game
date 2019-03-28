using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpiderHeartScript : MonoBehaviour {

    public GameObject spider;
    //private int spiderHealth;
    public float spiderDamage;
    public float spiderHealth;
    private float spiderDmgReceivedAmp;


    // Use this for initialization
    void Start()
    {
        if (spider != null)
            transform.position = spider.transform.position;
        spiderDmgReceivedAmp = 10;
    }
	
	// Update is called once per frame
	void Update () {
        if (spider != null)
            transform.position = spider.transform.position;

        if(spiderHealth <= 0 && spider != null)
        {
            spider.SetActive(false);
        }
    }

    void DamageSpider(float playerDamage)
    {
        spiderHealth -= playerDamage * spiderDmgReceivedAmp * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (spider != null)
            transform.position = spider.transform.position;
        if (other.gameObject.tag == "Player")
        {
            
            other.SendMessage("ReceiveDamage", spiderDamage, SendMessageOptions.DontRequireReceiver);

        }
    }

}
