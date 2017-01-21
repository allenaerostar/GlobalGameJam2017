using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Test Countdown
		//GetComponent<Timer> ().countdown(5);

		//Test Timer
		GetComponent<Timer> ().maxTimeInSeconds = 10;
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<Text> ().text = GetComponent<Timer> ().countdownNum.ToString();
		GetComponent<Text> ().text = GetComponent<Timer> ().getClockTime();
	}
}
