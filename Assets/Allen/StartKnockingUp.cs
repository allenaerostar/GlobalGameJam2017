using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKnockingUp : MonoBehaviour {

	public GameObject block1;
	// Use this for initialization
	void Start () {
		block1.GetComponent<KnockUpBlock>().StartKnockUp (3,2, true);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
