using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject ball;
	public GameObject[] players; // Needs at least one player to function properly
	public float normalSpeed; // The normal speed of the lerp. Recommend ~0.05
	public float slowSpeed; // Slower speed of the lerp after a player enters or leaves boundaries. Recommend ~0.03
	public float slowSpeedTime; // How long the slowSpeed lasts in seconds. Recommend ~3
	public float distanceThreshold; // Distance from the edge of the screen for player to be considered offscreen. Recommend ~100

	private Vector3 offset;
	private float midpoint;
	private Vector3 newPosition;
	private Camera camera;
	private bool reconsiderPlayer;
	private float currentSpeed;

	private float min;
	private float max;

	// Use this for initialization
	void Start () {
		offset = transform.position;
		camera = GetComponent<Camera> ();
		reconsiderPlayer = false;
		currentSpeed = normalSpeed;
	}
	
	void LateUpdate () {
		reconsiderPlayer = false;
		// if ball hasn't been destroyed
		if (ball != null) {
			// set min and max to ball's x (this means the ball is always considered in the midpoint calcuation)
			min = ball.transform.position.x;
			max = ball.transform.position.x;
		} else {
			min = players[0].transform.position.x;
			max = players[0].transform.position.x;
		}
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
				StartCoroutine(StartSlowSpeed ());
			}
		}
		midpoint = (min + max)/2;
		newPosition = new Vector3 (midpoint, 0, 0);
		transform.position = Vector3.Lerp (this.transform.position, newPosition + offset, currentSpeed);
	}

	IEnumerator StartSlowSpeed(){
		float currTime = 0f;
		float timeElapsed = 0f;
		while(timeElapsed < slowSpeedTime){
			currentSpeed = slowSpeed;
			timeElapsed += Time.deltaTime;
			yield return null;
		}
		currentSpeed = normalSpeed;
	}

	// get new ball when a goal is made and the current ball is destroyed
	public void setNewBall(GameObject newBall){
		ball = newBall;
	}
}

