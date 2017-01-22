using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSummary : MonoBehaviour {

	public Text points;
	public Text airtime;
	public Text slams;
	public Text spikes;

	public void setStats(string pointsValue, string airtimeValue, string slamsValue, string spikesValue) {
		points.GetComponent<Text> ().text = pointsValue;
		airtime.GetComponent<Text> ().text  = airtimeValue;
		airtime.color = Color.yellow;
		slams.GetComponent<Text> ().text  = slamsValue;
		spikes.GetComponent<Text> ().text  = spikesValue;
	}
}
