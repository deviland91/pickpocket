using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStraffing : MonoBehaviour {
    public float Speed = 10;
    private float Strafe;
    //private bool right = false;
    //private bool left = false;

    void Start()
    {
        Strafe = 0;
    }
    public void LeftButtonDown()
    {
        Strafe = Speed;
        //transform.Translate(Vector3.left * Strafe * Time.deltaTime);
        Debug.Log("left");
    }

    public void ButtonUp()
    {
        Strafe = 0;
        Debug.Log("Button Up");
    }

    public void RightButtonDown()
    {
        Strafe = -Speed;
        //transform.Translate(Vector3.right * Strafe * Time.deltaTime);
        Debug.Log("right");
    }

    void Update ()
    {
        transform.Translate(Vector3.left * Strafe * Time.deltaTime);

    }
}
