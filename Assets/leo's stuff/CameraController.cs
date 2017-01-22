using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject ball;
	public GameObject[] players;
	public float speed;
	public float slowSpeed;
	public float distanceThreshold;

	private Vector3 offset;
	private float midpoint;
	private Vector3 newPosition;
	private Camera camera;
	private bool reconsiderPlayer;


	// Use this for initialization
	void Start () {
		offset = transform.position;
		camera = GetComponent<Camera> ();
		reconsiderPlayer = false;
	}
	
	void LateUpdate () {
		reconsiderPlayer = false;
		// set min and max to ball's x (this means the ball is always considered in the midpoint calcuation)
		float min = ball.transform.position.x;
		float max = ball.transform.position.x;
		foreach (GameObject player in players){
			float playerX = player.transform.position.x;

			// check that it's not too far offscreen
			if (!(camera.WorldToScreenPoint (player.transform.position).x < (0 - distanceThreshold)) &&
				!(camera.WorldToScreenPoint (player.transform.position).x > (camera.pixelWidth + distanceThreshold))) {
				if (playerX > max) {
					max = playerX;
				} else if (playerX < min) {
					min = playerX;
				}
			} else {
				reconsiderPlayer = true;
			}
		}
		midpoint = (min + max)/2;
		newPosition = new Vector3 (midpoint, 0, 0);
		if (!reconsiderPlayer) {
			transform.position = Vector3.Lerp (this.transform.position, newPosition + offset, speed);
		} else {
			transform.position = Vector3.Lerp (this.transform.position, newPosition + offset, slowSpeed);
		}
	}
}

