using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public int playerNo;

	string horizontal;
	float dir;
	Rigidbody2D rb;
	bool facingRight = true;
	Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		horizontal = "Horizontal" + playerNo;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		dir = Input.GetAxis (horizontal);

		if (GetComponent<PlayerController> ().canMove) {
			anim.SetFloat ("speed", Mathf.Abs (speed * dir));
			if (dir < -0.05f && facingRight) {
				facingRight = false;
				transform.localScale = new Vector3 (-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
			} else if (dir > 0.05f && !facingRight) {
				facingRight = true;
				transform.localScale = new Vector3 (-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
			}
		}
	}

	void FixedUpdate(){
		Debug.Log (dir);
		rb.velocity = new Vector2(dir * speed, rb.velocity.y);
	}
}
