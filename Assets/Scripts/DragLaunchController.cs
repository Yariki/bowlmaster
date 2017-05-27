using System.Collections;
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
            ball.Move(new Vector3(amount, 0, 0));
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
