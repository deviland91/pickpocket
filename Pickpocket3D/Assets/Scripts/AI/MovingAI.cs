using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAI : MonoBehaviour {

    public float moveSpeed = 10f;
    public float turnSpeed = 50f;


    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
