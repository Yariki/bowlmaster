using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour
{
    private int lastStandingCount = -1;
    private float lastChangeTime;
    private bool ballOutOfPlay = false;
    private BallScript ball;
    private int lastSettledPins = 10;
    private ActionMaster actionMaster = new ActionMaster();
    private Animator animator;

    public Text countText;

    public GameObject pins;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.FindObjectOfType<BallScript>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countText)
        {
            countText.text = CountStanding().ToString();
        }
        if (ballOutOfPlay)
        {
            CheckStanding();
        }
    }

    public void SetBallOutOfPlay()
    {
        ballOutOfPlay = true;
    }

    public void RaisePins()
    {
        Debug.Log("Raising pins");
        foreach (PinController pinController in GameObject.FindObjectsOfType<PinController>())
        {
            pinController.RaiseIfStanding();
        }
    }

    public void LowerPins()
    {
        Debug.Log("Lowering pins");

        foreach (PinController pinController in GameObject.FindObjectsOfType<PinController>())
        {
            pinController.Lower();
        }
    }

    public void RenewPins()
    {
        Debug.Log("Renew pins");
        Instantiate(pins, new Vector3(0, 0.5f, 1829), Quaternion.identity);
    }


    int CountStanding()
    {
        int countStanding = 0;
        foreach (PinController pinController in GameObject.FindObjectsOfType<PinController>())
        {
            if (pinController.IsStanding())
            {
                countStanding++;
            }
        }
        return countStanding;
    }



    void OnTriggerEnter(Collider collider)
    {

        print("Triggered");

        GameObject thingEnter = collider.gameObject;
        if (thingEnter.GetComponent<BallScript>())
        {
            ballOutOfPlay = true;
            countText.color = Color.red;
        }
    }

    void CheckStanding()
    {
        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float timeThreshold = 3f;
        if ((Time.time - lastChangeTime) > timeThreshold)
        {
            PinHaveSettled();
        }
    }


    void PinHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledPins - standing;
        lastSettledPins = standing;

        ActionMaster.Action action = actionMaster.Bowl(pinFall);

        switch (action)
        {
            case ActionMaster.Action.Tidy:

                animator.SetTrigger("tidyTrigger");

                break;
            case ActionMaster.Action.Reset:
            case ActionMaster.Action.EndTurn:
                animator.SetTrigger("resetTrigger");
                lastSettledPins = 10;
                break;
            case ActionMaster.Action.EndGame:
                throw new UnityException("Not know how to handle end of the game");
        }


        ball.Reset();
        countText.color = Color.green;
        ballOutOfPlay = false;
        lastStandingCount = -1;
    }

}
