using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockUpAudience : MonoBehaviour {

	public Animator anim;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	bool grounded = false;
	float groundRadius = 0.1f;

	// Use this for initialization
	void Start () {	
		anim = GetComponent<Animator> ();
	}
		
	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
	}
}
