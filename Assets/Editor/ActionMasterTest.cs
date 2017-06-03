using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ActionMasterTest
{
    private List<int> pinFalls;

    ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    ActionMaster.Action reset = ActionMaster.Action.Reset;
    ActionMaster.Action endGame = ActionMaster.Action.EndGame;


    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
    }


    [Test]
    public void T00ONeStrikeReturnsEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }


    [Test]
    public void T01Bowl8ReturnsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02Spare28ReturnsEndTirn()
    {
        int[] rolls = {8, 2};
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }


    [Test]
    public void T03CheckResetAtStrikeInLAstFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
        
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T04CheckResetAtStrikeInLAstFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1,9};
        
        Assert.AreEqual(reset,ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T05RollsEndInendGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T06EndGameAtBowl20()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1};
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07_1_Bowl20Test()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T08_2_Bowl20Test()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10,0 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }


    [Test]
    public void T09_0_10_5()
    {
        int[] rolls = { 0, 10, 5, 0 };
       
        Assert.AreEqual(endTurn,ActionMaster.NextAction(rolls.ToList()));
    }


    [Test]
    public void T10_3_Strikes()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10,10,10 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T11ZeroOneReturnEndTurn()
    {
        int[] rolls = {0, 1};
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

}

