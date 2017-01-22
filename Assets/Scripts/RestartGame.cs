using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour {

	private Button restartButton;

	// Use this for initialization
	void Start () {
		restartButton = GetComponent<Button> ();
		restartButton.onClick.AddListener (Restart);
	}

	void Restart(){
		// restart the game here


	}
}
