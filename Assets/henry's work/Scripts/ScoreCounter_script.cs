using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter_script : MonoBehaviour {

    //public variables to hold the current scores of both teams.
    public int teamBlueScore;
    public int teamRedScore;

    void Start()
    {
        teamBlueScore = 0;
        teamRedScore = 0;
    }

    void Update()
    {

    }
	
    void restartScore()
    {
        teamBlueScore = 0;
        teamRedScore = 0;
    }
}
