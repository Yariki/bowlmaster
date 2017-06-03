using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<int> rolls = new List<int>();

    private PinSetterController pinSetter;
    private BallScript ball;
    private ScoreDisplayController scoreDisplayController;


    // Use this for initialization
    void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetterController>();
        ball = GameObject.FindObjectOfType<BallScript>();
        scoreDisplayController = GameObject.FindObjectOfType<ScoreDisplayController>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Bowl(int pinFall)
    {
        rolls.Add(pinFall);
        ball.Reset();

        scoreDisplayController.FillRools(rolls);
        scoreDisplayController.FillScores(rolls);

        pinSetter.PerformAction(ActionMaster.NextAction(rolls));
    }
}
