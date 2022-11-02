using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : Interactable
{

    public Item item;

    public override void Interact()
    {
        PickUpItem();
    }

    public void PickUpItem()
    {
        InventoryManager.Instance.AddItem(item);

        InventoryManager.Instance.ListItems();

        Destroy(gameObject);

    }
}
