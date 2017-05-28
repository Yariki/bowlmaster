using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<int> bowls = new List<int>();

    private PinSetterController pinSetter;
    private BallScript ball;


    // Use this for initialization
    void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetterController>();
        ball = GameObject.FindObjectOfType<BallScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Bowl(int pinFall)
    {
        bowls.Add(pinFall);

        ActionMaster.Action currentAction = ActionMaster.NextAction(bowls);

        pinSetter.PerformAction(currentAction);
        ball.Reset();
    }
}
