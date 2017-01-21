using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerLeo : MonoBehaviour {

	public Text timerDisplay;

	public float maxTimeInSeconds;
	public float timeInSeconds;

	public bool counting = false;

	// Use this for initialization
	void Start () {
		timerDisplay = GetComponent<Text>();
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
		timerDisplay.text = getClockTime ();
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
		int min = (int)(timeInSeconds / 60);
		int sec = (int)timeInSeconds - (min*60);
		// return value depends on if sec has only 1 digit
		if (sec < 10) {
			return (min + ":0" + sec);
		} else {
			return (min + ":" + sec);
		}
	}
}
