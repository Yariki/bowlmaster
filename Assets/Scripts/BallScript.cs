using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class BallScript : MonoBehaviour
{

    public float launchSpeed;

    private Rigidbody rigidbody;
    private AudioSource audioSource;
    private Vector3 ballIntPos;

    public bool IsInPlay { get; private set; }

    // Use this for initialization
    void Start()
    {
        IsInPlay = false;
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rigidbody.useGravity = false;
        ballIntPos = transform.position;
    }

    public void Move(Vector3 moveVector)
    {
        transform.Translate(moveVector);
    }

    public void Launch(Vector3 velocity)
    {
        if (rigidbody)
        {
            rigidbody.useGravity = true;
            rigidbody.velocity = velocity;
        }
        if (audioSource)
        {
            audioSource.Play();
        }
        IsInPlay = true;
    }

    public void Reset()
    {
        IsInPlay = false;
        rigidbody.useGravity = false;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        transform.position = ballIntPos;
    }

}
