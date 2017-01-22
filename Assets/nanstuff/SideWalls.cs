using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {

    // ATM SideWalls must be attached to a gameObject with position at origin,
    // otherwise ceiling trigger will be off center! Attach this script to an
    // independent gameObject if you must

    EdgeCollider2D ceiling;
    float height;
    Camera c;
    float baseHeight;

    BoxCollider2D leftWall, rightWall;

    // Use this for initialization
    void Start () {

        leftWall = GameObject.Find("leftWall").GetComponent<BoxCollider2D>();
        rightWall = GameObject.Find("rightWall").GetComponent<BoxCollider2D>();

        baseHeight = leftWall.size.y;
        height = baseHeight;
        ceiling = gameObject.AddComponent<EdgeCollider2D>();
        ceiling.points = new Vector2[] { new Vector2(leftWall.transform.position.x - transform.position.x, leftWall.transform.position.y + baseHeight/2 - transform.position.y),
                                         new Vector2(rightWall.transform.position.x - transform.position.x, rightWall.transform.position.y + baseHeight/2 - transform.position.y)};
        ceiling.isTrigger = true;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float heightInc = height;
        leftWall.size = new Vector2(leftWall.size.x, leftWall.size.y + heightInc);
        leftWall.offset = new Vector2(0, heightInc - baseHeight/2);
        rightWall.size = new Vector2(rightWall.size.x, rightWall.size.y + heightInc);
        rightWall.offset = new Vector2(0, heightInc - baseHeight / 2);

        Vector2[] ptList = ceiling.points;
        for (int i = 0; i < ceiling.points.Length; i++) {
            ptList[i].y += heightInc;
        }
        ceiling.points = ptList;
        height *= 2;
        Debug.Log("New height!");
    } 
}
