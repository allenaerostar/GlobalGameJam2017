using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHorn_script : MonoBehaviour {

    Animator anim;
    AudioSource airhornAudio;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        airhornAudio = gameObject.GetComponent<AudioSource>();
    }

    public void playHorn()
    {
        anim.SetTrigger("PlayHorn");
        airhornAudio.Play();
    }
}
