using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RunnerController : MonoBehaviour
{                   //SADECE MOVEMENT KODLARI
    public bool isRunning;
    public Rigidbody rb;
    public float speed;
    public float sideSpeed;
    private Vector3 swipeStartPosition, swipeEndPosition;
    private float swipeTime, swipeDistance;
    public float maxSwipeTime, minSwipeTime;
    float swipeStartTime;

    void Start()
    {  
        isRunning = true;
        sideSpeed = 5;
        maxSwipeTime = 999f;
        minSwipeTime = 0.1f;    
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = 0f;

        if (Input.GetMouseButtonDown(0))
        {
            swipeStartPosition = Input.mousePosition;
            swipeStartTime = Time.time; 
        }
        else if (Input.GetMouseButton(0))
        {
            swipeEndPosition = Input.mousePosition;
            swipeDistance = (swipeEndPosition - swipeStartPosition).magnitude; //
            swipeTime = Time.time - swipeStartTime;

            if(swipeTime < maxSwipeTime && swipeDistance > minSwipeTime)
            {
                Vector2 swipe = swipeEndPosition - swipeStartPosition;

                moveX = swipe.x;
            }
        }
        moveX = Mathf.Clamp(moveX, -1f, 1f);

        transform.Translate(transform.right * moveX * sideSpeed * Time.deltaTime);

        if (isRunning)
        {
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
    }
}
