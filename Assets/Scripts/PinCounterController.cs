using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounterController : MonoBehaviour
{

    public Text countText;

    private int lastStandingCount = -1;
    private float lastChangeTime;
    private bool ballOutOfPlay = false;
    private int lastSettledPins = 10;

    private GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
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

    public void Reset()
    {
        lastSettledPins = 10;
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

        gameManager.Bowl(pinFall);

        countText.color = Color.green;
        ballOutOfPlay = false;
        lastStandingCount = -1;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<BallScript>())
        {
            ballOutOfPlay = true;
        }
    }
}
