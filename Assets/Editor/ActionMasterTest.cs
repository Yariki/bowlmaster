using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ActionMasterTest
{

    ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;

    [Test]
    public void T00ONeStrikeReturnsEndTurn()
    {
        ActionMaster actionsMaster = new ActionMaster();
        Assert.AreEqual(endTurn,actionsMaster.Bowl(10));
    }

}

