using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    
    public enum InteractionType
    {
        Click,
        Puzzle
    }

    public InteractionType interactionType;

    protected void Awake()
    {
        var outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 2f;
        outline.enabled = false;
    }

    public abstract string GetName();
    public abstract string GetInteraction();
    public abstract void Interact();
    
}
    
