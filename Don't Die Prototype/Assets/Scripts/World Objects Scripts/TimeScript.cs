using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour {



    public int currentDay;
    public float dayNightCounter;
    public float dayCounter;
    public bool isDay;

    /*
        Day1-7: 8 Mins
        Dead From Hunger in 4 Mins no eating
        2 Minutes for water
    */
	// Use this for initialization
	void Start () {
        currentDay = 0;
        dayNightCounter = 480;//Day 8 Mins 480 secs
        dayCounter = 240; //day night
	}
	
	// Update is called once per frame
	void Update () {
        dayNightCounter -= Time.deltaTime;

        if(dayNightCounter <= 0)
        {
            currentDay++;
            dayNightCounter = 480;
        }
        if(dayCounter <= 0)
        {
            isDay = !isDay;
            dayCounter = 240;
        }
    }

    public bool GetIsDay() { return isDay; }
    public int GetCurrentDay() { return currentDay; }
}
