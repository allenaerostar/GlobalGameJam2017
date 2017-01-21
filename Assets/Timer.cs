using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public int maxTimeInSeconds;
	public int timeInSeconds;

	public float counting = false;

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
				timeInSeconds = 0;
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
		int min = timeInSeconds % 60;
		int sec = timeInSeconds - (timeInSeconds / 60);

		return (min + ":" + sec);
	}
}
