﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Timer> ().countdown(5);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = GetComponent<Timer> ().countdownNum.ToString();
	}
}
