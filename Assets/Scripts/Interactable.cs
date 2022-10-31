using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [TextArea(3, 10)][SerializeField] private string interactableDescription;

    public Item item;
    
    private void Awake()
    {
        var outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 2f;
        outline.enabled = false;
    }



    public string GetName()
    {
        return this.name;
    }
    public string GetInteractionDescription()
    {
        return interactableDescription;
    }
    
    public void Interact(GameObject itemObject)
    {
        InventoryManager.Instance.AddItem(item);
        Destroy(itemObject);
        Debug.Log("Interacting with " + this.name);
    }

}
    
