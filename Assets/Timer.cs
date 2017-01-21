using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public float maxTimeInSeconds;
	public float timeInSeconds;

	public bool counting = false;

	// Use this for initialization
	void Start () {
		timeInSeconds = maxTimeInSeconds;
		counting = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (counting) {
			timeInSeconds -= Time.deltaTime;
			//Finish Counting
			if (timeInSeconds < 0f) {
				timeInSeconds = 0f;
				counting = false;
			}
		}
	}

	//Start and pause timer
	public void pause(){
		counting = false;
	}

	public void resume(){
		counting = true;
	}

	//Get string of current time in min:sec
	public string getClockTime(){
		int min = (int)(timeInSeconds % 60);
		int sec = ((int)timeInSeconds - (int)(timeInSeconds / 60));

		return (min + ":" + sec);
	}
}
