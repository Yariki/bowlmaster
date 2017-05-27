using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBoxController : MonoBehaviour
{

    private PinSetterController pinSetter;

    // Use this for initialization
    void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetterController>();
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<BallScript>())
        {
            pinSetter.SetBallOutOfPlay();
        }
    }

}
