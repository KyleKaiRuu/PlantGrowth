using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddListenerToButton : MonoBehaviour
{
    public Shop shopScript;
    public string listener;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Shop").TryGetComponent(out Shop _shop))
        {
            shopScript = _shop;
        }
        if (gameObject.TryGetComponent(out Button button))
        {
            if (listener == "BuyOnClick")
            {
                button.onClick.AddListener(BuyOnClick);
            }
            else if (listener == "SellOnClick")
            {
                button.onClick.AddListener(SellOnClick);
            }
        }
    }

    void BuyOnClick()
    {
        if (gameObject.TryGetComponent(out Button button))
        {
            shopScript.BuyItem(button);
        }
    }

    void SellOnClick()
    {
        if (gameObject.TryGetComponent(out Button button))
        {
            shopScript.SellItem(button);
        }
    }
}
