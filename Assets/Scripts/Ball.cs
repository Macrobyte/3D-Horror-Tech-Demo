using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Interactable
{
    private new Rigidbody rigidbody;
    public float force = 10f;

    Transform lookingDiraction;

    private new void Awake()
    {
        base.Awake();
        rigidbody = GetComponent<Rigidbody>();
        lookingDiraction = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    public override string GetName()
    {
        return "<color=yellow>Ball</color>";
    }
    public override string GetInteraction()
    {
        return "Press <color=yellow>[E]</color> to kick the ball!";
    }

    public override void Interact()
    {
        rigidbody.AddForce(lookingDiraction.forward * force, ForceMode.Impulse);
    }

}
