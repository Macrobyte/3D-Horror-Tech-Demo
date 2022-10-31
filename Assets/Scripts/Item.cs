using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public int ItemId;
    public string itemName;
    public Sprite itemIcon;

    public GameObject itemPrefab;

}
