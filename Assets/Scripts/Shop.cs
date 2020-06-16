using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Serializable]
    public class ItemForSale
    {
        public ItemData item;
        public int cost;
        public int quantity;
    }

    public List<ItemForSale> itemsForSale;

    public List<GameObject> itemObjects;

    public GameObject shopItemDisplay;

    public PlayerCashStats playerCash;

    public InventoryManager inventory;

    private void Awake()
    {
        DisplayShop();
    }

    private void Update()
    {
        for (int i = 0; i < itemsForSale.Count; i++)
        {
            if (itemsForSale[i].quantity <= 0)
            {
                if (itemObjects[i].transform.GetChild(4).gameObject.TryGetComponent(out Button button))
                {
                    button.interactable = false;
                }
                else
                {
                    DebugWarningTryGetComponent("Item sprite", i.ToString());
                }
            }
            else
            {
                if (itemObjects[i].transform.GetChild(4).gameObject.TryGetComponent(out Button button))
                {
                    button.interactable = true;
                }
                else
                {
                    DebugWarningTryGetComponent("Item sprite", i.ToString());
                }
            }
        }
    }

    private void DisplayShop()
    {
        for (int i = 0; i < itemsForSale.Count; i++)
        {
            GameObject temp = Instantiate(shopItemDisplay, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
            itemObjects.Add(temp);
            if (temp.transform.GetChild(0).gameObject.TryGetComponent(out Text itemNameText))
            {
                itemNameText.text = itemsForSale[i].item.itemName;
            }
            else
            {
                DebugWarningTryGetComponent("Item name text", i.ToString());
            }

            if (temp.transform.GetChild(1).gameObject.TryGetComponent(out Text quantityText))
            {
                quantityText.text = "Quantity Available: " + itemsForSale[i].quantity.ToString();
            }
            else
            {
                DebugWarningTryGetComponent("Item quantity text", i.ToString());
            }

            if (temp.transform.GetChild(2).gameObject.TryGetComponent(out Text costText))
            {
                costText.text = "Cost: " + itemsForSale[i].cost.ToString();
            }
            else
            {
                DebugWarningTryGetComponent("Item cost text", i.ToString());
            }

            if (temp.transform.GetChild(3).gameObject.TryGetComponent(out Image itemSprite))
            {
                itemSprite.sprite = itemsForSale[i].item.sprite;
            }
            else
            {
                DebugWarningTryGetComponent("Item sprite", i.ToString());
            }
        }
    }

    public void BuyItem(Button buttonClicked)
    {
        GameObject temp = buttonClicked.gameObject.transform.parent.GetChild(0).gameObject;
        foreach(ItemForSale item in itemsForSale)
        {
            if (temp.TryGetComponent(out Text text))
            {
                if (text.text == item.item.itemName)
                {
                    if (playerCash.cash >= item.cost)
                    {
                        playerCash.cash -= item.cost;
                        item.quantity -= 1;
                        inventory.AddItem(item.item, 1);
                        UpdateDisplay();
                        Debug.Log("Purchased!");
                        return;
                    }
                    else
                    {
                        Debug.Log("You don't have enough cash for that!");
                        return;
                    }
                }
            }
            else
            {
                DebugWarningTryGetComponent("Item name ", "get item for cash.");
            }
        }
    }

    void UpdateDisplay()
    {
        for (int i = 0; i < itemsForSale.Count; i++)
        {
            if (itemObjects[i].transform.GetChild(1).gameObject.TryGetComponent(out Text quantityText))
            {
                quantityText.text = "Quantity Available: " + itemsForSale[i].quantity.ToString();
            }
            else
            {
                DebugWarningTryGetComponent("Item quantity text", i.ToString());
            }
        }
    }

    private void DebugWarningTryGetComponent(string firstString, string secondString)
    {
        Debug.LogWarning(firstString + " not found in the shop at index " + secondString);
    }
}