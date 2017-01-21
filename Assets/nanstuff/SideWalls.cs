using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {

    EdgeCollider2D leftEdge, rightEdge, ceiling;
    public int height;
    Camera c;
    float camYOffset;

	// Use this for initialization
	void Start () {
        c = GetComponent<Camera>();

        camYOffset = c.ViewportToWorldPoint(new Vector2(0.5f, 0)).y;
        GameObject leftWall = new GameObject("leftWall");
        leftWall.transform.position = c.ViewportToWorldPoint(Vector2.zero);
        GameObject rightWall = new GameObject("rightWall");
        rightWall.transform.position = c.ViewportToWorldPoint(Vector2.right);
        leftWall.layer = rightWall.layer = LayerMask.NameToLayer("Water");

        leftEdge = leftWall.AddComponent<EdgeCollider2D>();
        leftEdge.points = new Vector2[] { Vector3.zero, new Vector2(0, height)};

        rightEdge = rightWall.AddComponent<EdgeCollider2D>();
        rightEdge.points = new Vector2[] { Vector3.zero, new Vector2(0, height) };
        
        ceiling = gameObject.AddComponent<EdgeCollider2D>();
        ceiling.points = new Vector2[] { new Vector2(leftEdge.transform.position.x, leftEdge.transform.position.y + height + camYOffset), new Vector2(rightEdge.transform.position.x, rightEdge.transform.position.y + height + camYOffset)};

        ceiling.isTrigger = true;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        height *= 2;
        Vector2[] ptList = leftEdge.points;
        ptList[1].y = height;
        leftEdge.points = ptList;

        ptList = rightEdge.points;
        ptList[1].y = height;
        rightEdge.points = ptList;

        ptList = ceiling.points;
        for (int i = 0; i < ceiling.points.Length; i++) {
            ptList[i].y = height + camYOffset;
        }
        ceiling.points = ptList;
        Debug.Log("New height!");
    } 
}
