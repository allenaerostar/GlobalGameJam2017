using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBall_script : MonoBehaviour {

    Animator anim;
    public AnimationClip explosion;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public void ballExplode()
    {
        this.GetComponent<Rigidbody2D>().Sleep();
        anim.SetTrigger("isExploding");
        Destroy(gameObject, explosion.length);
        
    }
}
