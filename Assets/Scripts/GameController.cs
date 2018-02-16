using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText;
    public GameObject enemy;

    public static int scoreTotal = 0;
    public int total_enemies = 5;
    int current_enemies = 0;

	// Use this for initialization
	void Start () {
        scoreText.GetComponent<Text>();
        while(current_enemies < total_enemies)
        {
            Spawn();
            current_enemies++;
        }
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + scoreTotal;
	}

    void Spawn()
    {
        int spawnPointX = Random.Range(-22, 22);
        int spawnPointY = Random.Range(-12, 12);
        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, 0);

        Instantiate(enemy, spawnPosition, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }
}
