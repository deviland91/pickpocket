using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform player;
    public float distSpawnPlayer = 100;
    Vector3 spawnDistance;
    public Vector3 spawnerSize = new Vector3(15, 0, 15);

    // Use this for initialization
    void Start () {
        spawnDistance = new Vector3(0, 0, distSpawnPlayer);
        BoxCollider spawner = GetComponent<BoxCollider>();
        spawner.size = spawnerSize;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position + spawnDistance;

    }
}
