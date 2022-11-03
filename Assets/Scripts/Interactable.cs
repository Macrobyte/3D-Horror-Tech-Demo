using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [TextArea(3, 10)][SerializeField] private string interactableDescription;
    private GameObject player;

    public enum InteractableType
    {
        Item,
        Keypad,
        Document
    }

    public InteractableType interactableType;
    
    public void Awake()
    {
        player = FindObjectOfType<FirstPersonController>().gameObject;
        AddOutline();
    }
    
    public string GetInteractionDescription()
    {
        return interactableDescription;
    }

    public string GetName()
    {
        return this.gameObject.name;
    }

    public virtual void EnterInteraction()
    {
        player.GetComponent<PlayerInteraction>().enabled = false;
        player.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public virtual void ExitInteraction()
    {
        player.GetComponent<PlayerInteraction>().enabled = true;
        player.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void AddOutline()
    {
        var outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 3f;
        outline.enabled = false;
    }

    
}

    
