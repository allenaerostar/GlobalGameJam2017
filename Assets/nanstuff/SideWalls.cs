using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {

    EdgeCollider2D leftEdge, rightEdge;
    GameObject ceilingCheck;
    public int height;
    Camera c;

	// Use this for initialization
	void Start () {
        c = GetComponent<Camera>();
        GameObject leftWall = new GameObject("leftWall");
        leftWall.transform.position = c.ScreenToWorldPoint(Vector2.zero);
        GameObject rightWall = new GameObject("rightWall");
        rightWall.transform.position = c.ScreenToWorldPoint(Vector2.right);

        ceilingCheck = new GameObject("ceilingCheck");
        ceilingCheck.transform.position = Vector3.zero;

        leftEdge = leftWall.AddComponent<EdgeCollider2D>();
        leftEdge.points = new Vector2[] { leftWall.transform.position, new Vector2(leftWall.transform.position.x, leftWall.transform.position.y + height)};

        rightEdge = rightWall.AddComponent<EdgeCollider2D>();
        rightEdge.points = new Vector2[] { rightWall.transform.position, new Vector2(rightWall.transform.position.x, rightWall.transform.position.y + height) };

        EdgeCollider2D ceiling = ceilingCheck.AddComponent<EdgeCollider2D>();
        ceiling.points = new Vector2[] { leftEdge.points[1], rightEdge.points[2] };
        ceiling.isTrigger = true;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        leftEdge.points[1] = leftEdge.points[1] + new Vector2(0, height);
        rightEdge.points[1] = rightEdge.points[1] + new Vector2(0, height);
        Vector3 ceilPos = ceilingCheck.transform.position;
        ceilPos.z += height;
        ceilingCheck.transform.position = ceilPos;
    } 
}
