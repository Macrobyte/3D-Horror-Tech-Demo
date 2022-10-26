using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Click,
        Puzzle
        
    }

    public InteractionType interactionType;

    public abstract string GetDescription();
    public abstract void Interact();
    


    public void Highlight(bool state)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(state);     
    }
}
