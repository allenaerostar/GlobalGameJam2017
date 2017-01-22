using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	private Button restartButton;

	// Use this for initialization
	void Start () {
		restartButton = GetComponent<Button> ();
		restartButton.onClick.AddListener (Restart);
	}

	void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	// Can also restart with R or the space bar
	void Update(){
		if (Input.GetKeyDown (KeyCode.R) || Input.GetKeyDown (KeyCode.Space)) {
			Restart ();
		}
	}
}
