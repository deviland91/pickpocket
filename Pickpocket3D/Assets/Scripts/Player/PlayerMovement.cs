using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
        public float playerForce = 10;
        public float speed = 3;
        float horSpeed = 0;
        public float DampSpeed = 10f;
        public float RotateSpeed = 5f;
        
        [Range(-60, 60)]
        public int rotateDegree;

        Animator animator;

        // Use this for initialization
        void Start()
        {
        //EventTrigger.Entry entry = new EventTrigger.Entry();
        //entry.eventID = EventTriggerType.PointerDown;
            animator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            animator.SetFloat("Speed_f", speed, DampSpeed, Time.deltaTime);
            animator.SetFloat("Head_Horizontal_f", horSpeed, DampSpeed, Time.deltaTime);
            animator.SetFloat("Body_Horizontal_f", horSpeed, DampSpeed, Time.deltaTime);
            Quaternion target = Quaternion.Euler(0, rotateDegree, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * RotateSpeed);
        }


        public void LeftButtonDown()
        {
            horSpeed = -1;
            rotateDegree = -50;
            Debug.Log("Left Button Down");
        }

        public void ButtonUp()
        {
            horSpeed = 0;
            rotateDegree = 0;
            Debug.Log("Button Up");
        }

        public void RightButtonDown()
        {
            horSpeed = 1;
            rotateDegree = 50;
            Debug.Log("Right Button Down");
        }

}
