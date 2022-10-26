using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Interactable
{
    private new Rigidbody rigidbody;
    public float force = 10f;

    Transform lookingDiraction;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        lookingDiraction = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    public override string GetDescription()
    {
        return "Press <color=yellow>[E]</color> to kick the ball";
    }

    public override void Interact()
    {
        Debug.Log("Picked up the ball");
        rigidbody.AddForce(lookingDiraction.forward * force, ForceMode.Impulse);
    }

}
