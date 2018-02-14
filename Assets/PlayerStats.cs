using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    Collider2D playerCollider;
    public GameObject[] hearts;
    public GameObject loseScreen;
    public Text FinalScore;
    int score;


    int lifes = 3;

	// Use this for initialization
	void Start ()
    {
        playerCollider = GetComponent<Collider2D>();
        
    }


    // Update is called once per frame
    void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("head")){
            Debug.Log("Touch enemy");
            hearts[lifes - 1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            
            if (lifes <= 1)
            {
                FinalScore.text = "Final Score: " + GameController.scoreTotal;
                loseScreen.SetActive(true);
                Time.timeScale = 0;
            }
            lifes--;
        }
        else if (other.CompareTag("Money"))
        {
            
            Debug.Log("Touch money");
            GameController.scoreTotal += 100;
        }
    }

    public void RestartGame()
    {
        loseScreen.SetActive(false);
        Time.timeScale = 1;
        GameController.scoreTotal = 0;
        SceneManager.LoadSceneAsync("Main");
    }
}
