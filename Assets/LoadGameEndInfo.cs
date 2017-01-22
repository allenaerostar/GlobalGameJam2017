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
	public Text blueUI;
	public Text redUI;

	void Start(){
		blueScore.GetComponent<Text> ().text = blueUI.GetComponent<Text> ().text;
		redScore.GetComponent<Text> ().text = redUI.GetComponent<Text> ().text;
		if (int.Parse (blueScore.GetComponent<Text> ().text) < int.Parse (redScore.GetComponent<Text> ().text)) {
			winnerText.color = blue;
			winnerText.GetComponent<Text> ().text = "BLUE TEAM WINS";
		} else {
			winnerText.color = red;
			winnerText.GetComponent<Text> ().text = "RED TEAM WINS";
		}
	}
}
