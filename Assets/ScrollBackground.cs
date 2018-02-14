using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ScrollBackground : MonoBehaviour {

    public float speed = 0.5f;
    private Vector2 offset = new Vector2 (0,0);
    float coordMov;
    float axisVert;
    float axisHori;

    Material backMaterial;

	// Use this for initialization
	void Start () {
        backMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        axisHori = CrossPlatformInputManager.GetAxis("Horizontal");
        axisVert = CrossPlatformInputManager.GetAxis("Vertical");
        coordMov = Time.time;
        if (axisHori > 0) {
            if(axisVert > 0)
                offset = new Vector2((coordMov * axisHori*0.1f), (coordMov * axisVert * 0.1f));
            else if(axisVert < 0)
                offset = new Vector2((coordMov * axisHori * 0.1f), (coordMov * axisVert * 0.1f));
            else
                offset = new Vector2((coordMov * axisHori * 0.1f), 0);
        }
        else if (axisHori < 0) {
            if (axisVert > 0)
                offset = new Vector2((coordMov * axisHori * 0.1f), (coordMov * axisVert * 0.1f));
            else if (axisVert < 0)
                offset = new Vector2((coordMov * axisHori * 0.1f), (coordMov * axisVert * 0.1f));
            else
                offset = new Vector2((coordMov * axisHori * 0.1f), 0);
        }


        //backMaterial.mainTextureOffset = offset;
	}
}
