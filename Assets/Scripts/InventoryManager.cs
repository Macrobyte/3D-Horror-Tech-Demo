using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;

    public InventoryController[] inventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
    
    public void UpdateInventory()
    {
        foreach (Transform child in itemContent)
        {
            Destroy(child.gameObject);
        }
        
        foreach (var item in items)
        {
            GameObject itemObject = Instantiate(inventoryItem, itemContent);
            var itemName = itemObject.transform.Find("ItemName").GetComponent<TMPro.TextMeshProUGUI>();
            var itemIcon = itemObject.transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;

        }


        
        inventoryItems = itemContent.GetComponentsInChildren<InventoryController>();

        for (int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }

    }

    
}
