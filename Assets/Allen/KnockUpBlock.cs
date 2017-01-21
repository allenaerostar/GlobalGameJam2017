using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockUpBlock : MonoBehaviour {
	
	public GameObject leftBlock;
	public GameObject rightBlock;
	public float seconds;


	// Use this for initialization
	void Start () {
	
	}

	IEnumerator KnockUp(int range, float force, bool direction){
		if (range != 0){
			GetComponent<Rigidbody2D> ().AddForce (transform.up * force, ForceMode2D.Impulse);

			//false = left, true = right
			yield return new WaitForSeconds (seconds);

			if (leftBlock!= null && !direction) {
				StartCoroutine (leftBlock.GetComponent<KnockUpBlock> ().KnockUp(range - 1, force, direction));
			} else if(rightBlock != null && direction) {
				StartCoroutine(rightBlock.GetComponent<KnockUpBlock>().KnockUp(range -1, force, direction));
			}
		}
	}

	public void StartKnockUp(int range, float force, bool direction){
		
		if (leftBlock!= null && !direction && range!= 0) {
			StartCoroutine (leftBlock.GetComponent<KnockUpBlock> ().KnockUp(range, force, direction));
		} else if(rightBlock != null && direction && range!= 0) {
			StartCoroutine(rightBlock.GetComponent<KnockUpBlock>().KnockUp(range, force, direction));
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
