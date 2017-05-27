using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{


    public float standingThreshold = 3f;
    public float distaneToRaise = 40f;


    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public bool IsStanding()
    {
        Vector3 rotating = transform.eulerAngles;
        float tiltinX = Mathf.Abs(270 - rotating.x);
        float tiltinZ = Mathf.Abs(rotating.z);

        return tiltinX < standingThreshold && tiltinZ < standingThreshold;
    }

    public void RaiseIfStanding()
    {
        if (IsStanding())
        {
            if (rigidbody)
            {
                rigidbody.useGravity = false;
                transform.Translate(new Vector3(0,distaneToRaise,0),Space.World);
                transform.rotation = Quaternion.Euler(new Vector3(270f,0,0));
            }
        }
    }

    public void Lower()
    {
        rigidbody.useGravity = true;
        transform.Translate(new Vector3(0,-distaneToRaise,0),Space.World);
        transform.rotation = Quaternion.Euler(new Vector3(270f, 0, 0));
    }

}
