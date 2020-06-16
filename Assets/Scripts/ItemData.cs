using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public int itemId;
    public string itemName;
    [TextArea (3,3)]
    public string itemDescription;
    public Sprite sprite;
    public InventoryManager.InvItem.Usage usage;
    public int useAmount;
    public InventoryManager.InvItem.Usage secondaryUsage;
    public int secondaryUseAmount;
    public int cost;
}
