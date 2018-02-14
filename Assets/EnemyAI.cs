using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    float randMove;
    bool shouldMove = false;
    public float speed = 0;
    public float rotSpeed = 100;
    public float damping = 5;
    bool rotate = false;
    float DesiredRot;
    Quaternion DesiredRotQ;
    Rigidbody2D enemyRB;

	// Use this for initialization
	void Start () {
        enemyRB = GetComponent<Rigidbody2D>();
        randMove = Random.Range(0.0f, 1.0f);
        if (randMove >= 0.5f)
        {
            shouldMove = true;
            StartCoroutine(Movement());
        }
	}
	
	// Update is called once per frame
	IEnumerator Movement()
    {
        while (true)
        {
            rotate = false;
            speed = 1;
            yield return new WaitForSecondsRealtime(3.0f);
            DesiredRot = Random.Range(-360.0f, 360.0f);
            DesiredRotQ = Quaternion.Euler(0.0f, 0.0f, DesiredRot);
            //speed = 0;
            rotate = true;
            yield return new WaitForSecondsRealtime(1.0f);
        }
        
    }

    private void Update()
    {
        if (shouldMove == true)
        {
            transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
        }

        if (rotate == true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, DesiredRotQ, Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        while (collision.CompareTag("boundary") == true)
        {
            DesiredRotQ = Quaternion.Euler(0.0f, 0.0f, transform.rotation.z/2);
            speed = -1;
        }
    }
}
