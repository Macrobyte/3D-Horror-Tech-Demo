using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;
    
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
    
    public void ListItems()
    {

        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }  

        foreach (var item in items)
        {
            GameObject itemObject = Instantiate(inventoryItem, itemContent);
            

            var itemName = itemObject.transform.Find("ItemName").GetComponent<TMPro.TextMeshProUGUI>();
            var itemIcon = itemObject.transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>();
            var controller = itemObject.transform.GetComponent<InventoryController>();

            controller.AddItem(item);


            itemObject.name = item.itemName;

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;

        }
    }

  

    
}
