using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	private Vector3 offset1;
	private Vector3 offset2;
	private Vector3 offset3;
	private Vector3 offset4;
	private Vector4 average;

	// Use this for initialization
	void Start () {
		offset1 = transform.position - player1.transform.position;
		offset2 = transform.position - player2.transform.position;
		offset3 = transform.position - player3.transform.position;
		offset4 = transform.position - player4.transform.position;
		average = (offset1 + offset2 + offset3 + offset4) / 4;


	}
	
	void LateUpdate(){
		
		transform.position.x = player1.transform.position.x + average.x;
		offset1 = transform.position - player1.transform.position;
		offset2 = transform.position - player2.transform.position;
		offset3 = transform.position - player3.transform.position;
		offset4 = transform.position - player4.transform.position;
		average = (offset1 + offset2 + offset3 + offset4) / 4;
	}
}
