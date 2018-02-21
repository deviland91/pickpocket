using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    private Rigidbody2D rgb2d;

	// Use this for initialization
	void Start () {
        rgb2d = GetComponent<Rigidbody2D>();
        rgb2d.velocity = new Vector2(-1.5f,-1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
