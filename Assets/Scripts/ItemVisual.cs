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
        if(gameObject.transform.GetChild(0).gameObject.TryGetComponent(out Image image))
        {
            image.sprite = itemSprite;
        }
        if (gameObject.transform.GetChild(1).gameObject.TryGetComponent(out Text text))
        {
            text.text = quantity.ToString();
        }
    }
}
