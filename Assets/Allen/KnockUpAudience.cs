using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockUpAudience : MonoBehaviour {

	public GameObject audienceBlock;
	public Animator anim;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	bool grounded = false;
	float groundRadius = 0.1f;
	// Use this for initialization
	void Start () {	
		anim = audienceBlock.GetComponent<Animator> ();
		KnockUp (5);
	}

	public void KnockUp(float force){

		audienceBlock.GetComponent<Rigidbody2D> ().AddForce (transform.up * force, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		//anim.SetFloat ("Speed", Mathf.Abs(audienceBlock.GetComponent<Rigidbody2D>().velocity.sqrMagnitude));
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
	}
}
