using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCashStats : MonoBehaviour
{
    public int cash = 0;

    public Text cashText;

    private void Update()
    {
        cashText.text = "Current cash: " + cash.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cash += 100;
        }
    }
}
