﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;

    public Vector3 offset;

    public float pitch = 2f;

    private float currentZoom = 10f;

	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.position - offset * currentZoom;
        transform.LookAt(player.position + Vector3.up * pitch);
	}
}
