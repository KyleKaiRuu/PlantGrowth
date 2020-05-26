using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemVisual : MonoBehaviour
{
    public InventoryManager invComp;
    public Sprite itemSprite;
    string itemName;
    public string itemDescription;
    public int itemNum;
    public int itemId;
    public int quantity;

    bool initialized;

    private void Awake()
    {
        if (GameObject.Find("Manager").TryGetComponent(out InventoryManager _im))
        {
            invComp = _im;
        }
    }

    private void Update()
    {
        if (!initialized)
        {
            if (invComp != null)
            {
                SetItems();
                initialized = true;
            }
        }
        UpdateItems();
    }

    void SetItems()
    {
        if (gameObject.transform.GetChild(0).TryGetComponent(out Image img))
        {
            img.sprite = itemSprite;
        }
        if (gameObject.transform.GetChild(1).TryGetComponent(out Text txt))
        {
            txt.text = quantity.ToString();
        }
    }

    void UpdateItems()
    {
        if (quantity == 0)
        {
            if (gameObject.transform.GetChild(0).gameObject.TryGetComponent(out Image img))
            {
                img.color = new Color(0, 0, 0, 0);
            }
            else
            {
                if (gameObject.transform.GetChild(0).gameObject.TryGetComponent(out Image im))
                {
                    img.color = Color.white;
                }
            }
        }

        InventoryManager.InvItem tempInvItem = invComp.inventory[itemNum];

        itemSprite = tempInvItem.sprite;
        itemName = tempInvItem.itemName;
        itemDescription = tempInvItem.itemDescription;
        quantity = tempInvItem.quantity;
        itemId = tempInvItem.itemId;

        if (tempInvItem.inInventory)
        {
            if (gameObject.transform.GetChild(0).TryGetComponent(out Image img))
            {
                img.sprite = itemSprite;
            }
            if (gameObject.transform.GetChild(1).TryGetComponent(out Text txt))
            {
                txt.text = quantity.ToString();
            }
        }
    }
}
