using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalNet_script : MonoBehaviour {

    AudioSource audiosource;

    //sets which team does the net belong to.
    public string teamOfNet;
    //references the scoreCounter GameObject.
    public GameObject scoreCounterRef;

    void Start()
    {
        audiosource = this.GetComponent<AudioSource>();
    }

    //Checks whenever the ball enters the net, call ballExplode() and updates team scores accordingly.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            audiosource.PlayDelayed(0.7f);
            other.GetComponent<GeneralBall_script>().ballExplode();
            if (teamOfNet == "Blue")
                scoreCounterRef.GetComponent<ScoreCounter_script>().teamBlueScore += 1;
            else if (teamOfNet == "Red")
                scoreCounterRef.GetComponent<ScoreCounter_script>().teamRedScore += 1;
            else
                Debug.Log(gameObject.name + " has teamOfNet variable set to an incorrect name, please set to either 'Red' or 'Blue'.");
        }
    }
}
