using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class Player2DController : MonoBehaviour {

    

    public float speed = 2;
    Rigidbody2D PlayerBody;
    Collider2D PlayerCollider;
    float lastAngle, angle = 0;

    Vector3 lastVect = new Vector3(1, 0, 0);


    void Start () {
        PlayerBody = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<Collider2D>();
	}
	
	void Update () {
        float dirHor = CnInputManager.GetAxis("Horizontal");
        float dirVer = CnInputManager.GetAxis("Vertical");
        

        //Vector2 moveVect = new Vector2(dirHor, dirVer) * speed;
        Vector3 rotVect = new Vector3(dirHor, dirVer , 0.0f);
        


        if (dirHor != 0 || dirVer != 0)
        {
            angle = Mathf.Atan2(dirVer, dirHor) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.RotateAround(PlayerCollider.bounds.center, Vector3.forward, angle);
            lastAngle = angle;
            transform.Translate(rotVect * speed * Time.deltaTime, Space.World);
            lastVect = new Vector3(dirHor, dirVer, 0.0f);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(lastAngle, Vector3.forward);
            transform.Translate(lastVect * speed * Time.deltaTime, Space.World);
        }






    }
}
