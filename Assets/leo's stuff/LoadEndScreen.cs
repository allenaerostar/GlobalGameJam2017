using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadEndScreen : MonoBehaviour {

	public Text winnerText;
	public Text redScore;
	public Text blueScore;
	public Color red;
	public Color blue;

	public GameObject player1;

	// Use this for initialization
	void Start () {
		redScore.GetComponent<Text> ().text  = "2";
		blueScore.GetComponent<Text> ().text  = "1000";

		player1.GetComponent<LoadSummary> ().setStats ("2", "1m25s", "25", "14");
		setWinnerBlue ();
	}

	void setWinnerRed() {
		winnerText.color = red;
		winnerText.GetComponent<Text> ().text = "RED TEAM WINS";
	}

	void setWinnerBlue() {
		winnerText.color = blue;
		winnerText.GetComponent<Text> ().text = "BLUE TEAM WINS";
	}
}
