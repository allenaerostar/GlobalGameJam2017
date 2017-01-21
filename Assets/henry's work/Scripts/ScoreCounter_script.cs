using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter_script : MonoBehaviour {

    //public variables to hold the current scores of both teams.
    public int teamBlueScore;
    public int teamRedScore;

    public Text BlueScoreUI;
    public Text RedScoreUI;

    void Start()
    {
        teamBlueScore = 0;
        teamRedScore = 0; 
    }

    void FixedUpdate()
    {
        BlueScoreUI.text = teamBlueScore.ToString();
        RedScoreUI.text = teamRedScore.ToString();
    }
	
    void restartScore()
    {
        teamBlueScore = 0;
        teamRedScore = 0;
    }
}
