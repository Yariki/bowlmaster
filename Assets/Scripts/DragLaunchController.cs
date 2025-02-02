﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallScript))]
public class DragLaunchController : MonoBehaviour
{

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    private BallScript ball;

    void Start()
    {
        ball = GetComponent<BallScript>();
    }

    public void MoveStart(float amount)
    {
        if (ball && !ball.IsInPlay)
        {
			float xPos = Mathf.Clamp(ball.transform.position.x + amount, -50, 50);
			float yPos = ball.transform.position.y;
			float zPos = ball.transform.position.z;
			ball.Move(new Vector3(xPos, yPos, zPos));
        }
    }

    public void DragStart()
    {
        if (ball && !ball.IsInPlay)
        {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }

    }

    public void DragEnd()
    {
        if (ball && !ball.IsInPlay)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float launchTime = endTime - startTime;

            float launchSpeedX = (dragEnd.x - dragStart.x) / launchTime;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / launchTime;

            ball.Launch(new Vector3(launchSpeedX, 0, launchSpeedZ));
        }

    }


}
