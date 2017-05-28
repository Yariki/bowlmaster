using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour
{
   
    
    
    private ActionMaster actionMaster = new ActionMaster();
    private Animator animator;
    private PinCounterController pinCounter;

    

    public GameObject pins;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounterController>();
    }

    // Update is called once per frame
    void Update()
    {
       
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
    
    //void OnTriggerEnter(Collider collider)
    //{

    //    print("Triggered");

    //    GameObject thingEnter = collider.gameObject;
    //    if (thingEnter.GetComponent<BallScript>())
    //    {
    //        ballOutOfPlay = true;
    //    }
    //}

    public void PerformAction(ActionMaster.Action currentAction)
    {
        

        switch (currentAction)
        {
            case ActionMaster.Action.Tidy:

                animator.SetTrigger("tidyTrigger");

                break;
            case ActionMaster.Action.Reset:
            case ActionMaster.Action.EndTurn:
                animator.SetTrigger("resetTrigger");
                pinCounter.Reset();
                break;
            case ActionMaster.Action.EndGame:
                throw new UnityException("Not know how to handle end of the game");
        }
    }

}
