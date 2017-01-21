using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockRightAndLeft : MonoBehaviour {

	public GameObject leftAudience;
	public GameObject rightAudience;
	public GameObject lastObject;
	public float seconds;

	// Use this for initialization
	void Start () {

		StartCoroutine(KnockRightThenLeft (10, 5, true));
	}
		
	IEnumerator KnockUp(int range, float force, bool direction){
		if (range != 0){
			GetComponent<Rigidbody2D> ().AddForce (transform.up * force, ForceMode2D.Impulse);
			//false = left, true = right
			yield return new WaitForSeconds (seconds);

			if (leftAudience!= null && !direction) {
				StartCoroutine (leftAudience.GetComponent<KnockRightAndLeft> ().KnockUp(range - 1, force, direction));
			} else if(rightAudience != null && direction) {
				StartCoroutine(rightAudience.GetComponent<KnockRightAndLeft>().KnockUp(range -1, force, direction));
			}
		}
	}

	public void StartKnockUp(int range, float force, bool direction){

		if (leftAudience!= null && !direction && range!= 0) {
			StartCoroutine (leftAudience.GetComponent<KnockRightAndLeft> ().KnockUp(range, force, direction));
		} else if(rightAudience != null && direction && range!= 0) {
			StartCoroutine(rightAudience.GetComponent<KnockRightAndLeft>().KnockUp(range, force, direction));
		}
	}

	IEnumerator KnockRightThenLeft(int range, float force, bool direction){
		
		StartKnockUp(range, force, direction);
		print ("left to right");
		yield return new WaitForSeconds(seconds);
		lastObject.GetComponent<KnockRightAndLeft>().StartKnockUp (range, force, !direction);
		print ("right to left");
	}
}
