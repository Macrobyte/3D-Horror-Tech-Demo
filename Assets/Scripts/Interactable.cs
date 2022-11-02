using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [TextArea(3, 10)][SerializeField] private string interactableDescription;

    public enum InteractableType
    {
        Item,
        Keypad
    }

    public InteractableType interactableType;
    
    public void Awake()
    {
        var outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 3f;
        outline.enabled = false;
    }
    
    public string GetInteractionDescription()
    {
        return interactableDescription;
    }

    public string GetName()
    {
        return this.gameObject.name;
    }

    public abstract void Interact();
    
}

    
