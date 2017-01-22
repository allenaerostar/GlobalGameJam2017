using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour {

	public GameObject[] spawns;
	public GameObject getTime;
	public GameObject ballPrefab;

	public GameObject teamBlueScore;
	public GameObject teamRedScore;

	// Use this for initialization
	void Start () {
        getTime.GetComponent<Timer>().pauseTimer();
        StartCoroutine (watchForEnd());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void resetAllPositions(){
		//Reset players
		foreach (GameObject obj in spawns) {
			obj.GetComponent<PlayerReposition_script> ().resetPos ();
		}

        //spawns ball
        Invoke("ballSpawn", 3f);

	}

    void ballSpawn()
    {
        GameObject ball = (GameObject)Instantiate(ballPrefab);
        ball.transform.position = new Vector2(0, 2);
    }

	IEnumerator watchForEnd(){
		while (getTime.GetComponent<Timer> ().timeInSeconds > 0f) {
			yield return new WaitForSeconds(getTime.GetComponent<Timer> ().timeInSeconds);
		}
		//We're in overtime now
		int teamBlueCurrentScore = teamBlueScore.GetComponent<ScoreCounter_script>().teamBlueScore;
		int teamRedCurrentScore = teamRedScore.GetComponent<ScoreCounter_script>().teamRedScore;

		while (teamBlueCurrentScore == teamBlueScore.GetComponent<ScoreCounter_script> ().teamBlueScore &&
		      teamRedCurrentScore == teamRedScore.GetComponent<ScoreCounter_script> ().teamRedScore) {
			yield return new WaitForFixedUpdate ();
		}

		//After overtime
		//Show some UI

	}
}
