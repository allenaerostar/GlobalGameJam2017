using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointerArrow : MonoBehaviour {

	SpriteRenderer sprite;
	public Sprite arrow;
	public Sprite offScreenArrow;
	public GameObject player;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
