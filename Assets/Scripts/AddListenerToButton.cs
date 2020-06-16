using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddListenerToButton : MonoBehaviour
{
    public Shop shopScript; 
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Shop").TryGetComponent(out Shop _shop))
        {
            shopScript = _shop;
        }
        if (gameObject.TryGetComponent(out Button button))
        {
            button.onClick.AddListener(BuyOnClick);
        }
    }

    void BuyOnClick()
    {
        if (gameObject.TryGetComponent(out Button button))
        {
            shopScript.BuyItem(button);
        }
    }
}
