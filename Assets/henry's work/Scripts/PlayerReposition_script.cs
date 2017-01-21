using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReposition_script : MonoBehaviour {

    public Vector2 startPosition;

    void Start()
    {
        this.transform.position = startPosition;
    }

    public void resetPos()
    {
        this.transform.position = startPosition;
    }
	
}
