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
    private bool ballEnteredIntoBox = false;
    private BallScript ball;

    public Text countText;
    
    public GameObject pins;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.FindObjectOfType<BallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countText)
        {
            countText.text = CountStanding().ToString();
        }
        if (ballEnteredIntoBox)
        {
            CheckStanding();
        }
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
        Instantiate(pins, new Vector3(0, 0, 1829), Quaternion.identity);
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
            ballEnteredIntoBox = true;
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
        ball.Reset();
        countText.color = Color.green;
        ballEnteredIntoBox = false;
        lastStandingCount = -1;
    }

}
