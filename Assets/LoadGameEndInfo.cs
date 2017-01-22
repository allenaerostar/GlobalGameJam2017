using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameEndInfo : MonoBehaviour {

	public Text winnerText;
	public Text blueScore;
	public Text redScore;
	public Color blue;
	public Color red;

	public void SetInfo(string winner, string bScore, string rScore){
		if (winner == "Blue") {
			winnerText.color = blue;
			winnerText.GetComponent<Text> ().text = "BLUE TEAM WINS";
		} else if (winner == "Red") {
			winnerText.color = red;
			winnerText.GetComponent<Text> ().text = "RED TEAM WINS";
		} else {
			Debug.Log ("Invalid winner passed. Must be Red or Blue.");
		}

		blueScore.GetComponent<Text> ().text = bScore;
		redScore.GetComponent<Text> ().text  = rScore;
	}
}
