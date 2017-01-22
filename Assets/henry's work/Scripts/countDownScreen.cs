using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countDownScreen : MonoBehaviour {

    public Text countdownDisplay;
    public GameObject timer;

    void Start()
    {
        timer.GetComponent<Timer>().countdown(3);
    }

    void Update()
    {
        countdownDisplay.text = timer.GetComponent<Timer>().countdownNum.ToString();
		if (timer.GetComponent<Timer> ().countdownNum == 0) {
			gameObject.SetActive (false);
			timer.GetComponent<Timer> ().counting = true;
		}
    }
}
