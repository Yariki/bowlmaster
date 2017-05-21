using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchrederController : MonoBehaviour {

    void OnTriggerExit(Collider collider)
    {

        print("Triggered Exit");

        GameObject thingLeft = collider.gameObject;
        if (thingLeft.GetComponent<PinController>())
        {
            Destroy(thingLeft);
        }
    }
}
