using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject template;

    public List<InvItem> inventory;
    [Serializable]
    public class InvItem
    {
        public int itemId;
        public string itemName;
        public string itemDescription;
        public int quantity;
        public Sprite sprite;
        public Usage usage;
        public int useAmount;
        public Usage secondaryUsage;
        public int secondaryUseAmount;
        public bool inInventory;

        public enum Usage
        {
            None,
            Taming,
            Healing,
            Mana
        }
        //Enum for use, would reference UseItem script in some way with Enums deciding effect and an int for amount

        public InvItem(int itemId, string itemName, string itemDescription, int quantity, Sprite sprite, Usage usage, int useAmount, Usage secondaryUsage, int secondaryUseAmount, bool inInventory)
        {
            this.itemId = itemId;
            this.itemName = itemName;
            this.itemDescription = itemDescription;
            this.quantity = quantity;
            this.sprite = sprite;
            this.usage = usage;
            this.useAmount = useAmount;
            this.secondaryUsage = secondaryUsage;
            this.secondaryUseAmount = secondaryUseAmount;
            this.inInventory = inInventory;
        }
    }

    int indexToUse = 0;

    int curNum = 0;

    private List<ItemVisual> itemVisuals = new List<ItemVisual>();


    public bool testing;
    public ItemData testItemToAdd;
    public int testQuantityAdd;
    public ItemData testItemToRemove;
    public int testQuantityRemove;

    public ItemData testSecondItemToAdd;
    public int testSecondQuantityToAdd;
    public ItemData testSecondItemToRemove;
    public int testSecondQuantityToRemove;

    public GameObject canvas;

    private void Awake()
    {
        inventory = new List<InvItem>();
    }

    private void Update()
    {
        if (testing)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AddItem(testItemToAdd, testQuantityAdd);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                RemoveItem(testItemToRemove, testQuantityRemove);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                AddItem(testSecondItemToAdd, testSecondQuantityToAdd);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                RemoveItem(testSecondItemToRemove, testSecondQuantityToRemove);
            }
        }
    }

    public void AddItem(ItemData item, int quantityToAdd)
    {
        bool isInInventory = false;
        indexToUse = 0;
        isInInventory = CheckIfInInventory(item);

        if (!isInInventory)
        {
            inventory.Add(new InvItem(item.itemId, item.itemName, item.itemDescription, quantityToAdd, item.sprite, item.usage, item.useAmount, item.secondaryUsage, item.secondaryUseAmount, true));
            UpdateVisual(item, true, false);
        }
        else
        {
            inventory[indexToUse].quantity += quantityToAdd;
            UpdateVisual(item, true, true);
        }
    }

    public void RemoveItem(ItemData item, int quantityToRemove)
    {
        bool isInInventory = false;
        indexToUse = 0;
        isInInventory = CheckIfInInventory(item);

        if (!isInInventory)
        {
            return;
        }

        else
        {
            foreach(InvItem invItem  in inventory)
            {
                if (invItem.itemId == item.itemId)
                {
                    if (invItem.quantity == quantityToRemove)
                    {
                        inventory.RemoveAt(indexToUse);
                        Debug.Log("Item Remmoved");
                        UpdateVisual(item, false, false);
                        return;
                    }
                    else if (invItem.quantity >= quantityToRemove)
                    {
                        inventory[indexToUse].quantity -= quantityToRemove;
                        UpdateVisual(item, false, true);
                        Debug.Log("Item Quantity Removed");
                        return;
                    }
                    else
                    {
                        Debug.Log("Insufficient quantity available");
                        return;
                    }
                }
            }
        }
    }

    private bool CheckIfInInventory(ItemData item)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            for (int j = 0; j < inventory.Count; j++)
            {
                if (inventory[j].itemId == item.itemId)
                {
                    indexToUse = j;
                    return true;
                }
            }

            if (i >= inventory.Count - 1)
            {
                indexToUse = i + 1;
                return false;
            }

            if (inventory[i].itemId == item.itemId)
            {
                indexToUse = i;
                return true;
            }
        }

        indexToUse = 0;
        return false;
    }

    public void UpdateVisual(ItemData item, bool isAdding, bool isChangingQuantity)
    {
        if (isAdding && !isChangingQuantity)
        {

            //Add new entry.
            GameObject cur = Instantiate(template, canvas.transform);
            if (cur.gameObject.TryGetComponent(out ItemVisual _iv))
            {
                _iv.itemNum = curNum;
                _iv.itemSprite = item.sprite;
                _iv.itemDescription = item.itemDescription;
                _iv.quantity = inventory[indexToUse].quantity;
                _iv.itemId = item.itemId;
                itemVisuals.Add(_iv);

            }
            cur.name = "Entry " + curNum.ToString();
            curNum++;

            if (gameObject.TryGetComponent(out RectTransform rectTransform))
            {
                if (rectTransform.rect.position != new Vector2(0, 0))
                {
                    rectTransform.rect.Set(0, 0, 0, 0);
                }
            }
        }
        else if (!isAdding && !isChangingQuantity)
        {
            //Destroy the one that's gone
            foreach (ItemVisual itemVisual in itemVisuals)
            {
                if (itemVisual.itemId == item.itemId)
                {
                    itemVisuals.Remove(itemVisual);
                    Destroy(itemVisual.gameObject);
                    curNum--;
                    return;
                }
            }
        }
        else
        {
            UpdateQuantity();
        }
    }

    void UpdateQuantity()
    {
        GameObject cur = itemVisuals[indexToUse].gameObject;
        if (cur.gameObject.TryGetComponent(out ItemVisual _iv))
        {
            _iv.quantity = inventory[indexToUse].quantity;
        }
    }
}
