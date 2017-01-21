using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter_script : MonoBehaviour {

    //public variables to hold the current scores of both teams.
    public int teamBlueScore;
    public int teamRedScore;

    //reference to score text UI.
    public Text BlueScoreUI;
    public Text RedScoreUI;

    void Start()
    {
        //Sets both team's scores to 0 at the start of the game.
        teamBlueScore = 0;
        teamRedScore = 0; 
    }

    void Update()
    {
        //Updates score text UI to the current scores.
        BlueScoreUI.text = teamBlueScore.ToString();
        RedScoreUI.text = teamRedScore.ToString();
    }
	
    //resets both team's score to 0.
    void restartScore()
    {
        teamBlueScore = 0;
        teamRedScore = 0;
    }
}
