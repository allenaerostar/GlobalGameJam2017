using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockUpAudience : MonoBehaviour {

	public Animator anim;
	public LayerMask whatIsGround;
	//public Transform groundCheck;
	public bool grounded = false;
	float groundRadius = 0.5f;

	// Use this for initialization
	void Start () {	
		anim = GetComponent<Animator> ();
		whatIsGround = LayerMask.GetMask("Stand");
	}
		
	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (transform.position + new Vector3(0, -1f, 0), groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
	}
}
