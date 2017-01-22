using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public float maxTimeInSeconds;
	public float timeInSeconds;

	public int countdownNum;
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
		if (timeInSeconds > 0f) {
			int min = (int)(timeInSeconds / 60);
			int sec = (int)timeInSeconds - (min * 60);
			// return value depends on if sec has only 1 digit
			if (sec < 10) {
				return (min + ":0" + sec);
			} else {
				return (min + ":" + sec);
			}
		} else {
			return "OVERTIME";
		}

	}

	public void pauseTimer(){
		Time.timeScale = 0;
	}

	public void resumeTimer(){
		Time.timeScale = 1;
	}

	//CountDown from 3 - 2 - 1
	public void countdown(int startFrom){
		//reset counter to startFrom
		countdownNum = startFrom;
		StartCoroutine (frozenCountdown());
	}


	IEnumerator frozenCountdown(){
		pauseTimer ();

		while (countdownNum > 0) {
			float start = Time.realtimeSinceStartup;
			while (Time.realtimeSinceStartup < start + 1f)
			{ 
				yield return null; 
			}
			countdownNum--;
		}

		resumeTimer ();
	}
}
