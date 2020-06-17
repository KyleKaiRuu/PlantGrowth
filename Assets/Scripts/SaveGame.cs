using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public Shop shopScript;
    public PlayerCashStats cashScript;
    public InventoryManager inventoryScript;

    public void SaveScripts()
    {
        cashScript.SaveCash();
        inventoryScript.SaveInventory();
    }
}
