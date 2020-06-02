using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftItem : MonoBehaviour
{
    public CraftingRecipe recipeToCraft;
    public InventoryManager inventoryManager;

    public bool canCraft;

    int itemsHave;
    int quantitiesHave;

    public void Craft()
    {
        if (CheckIfCanCraft())
        {
            inventoryManager.AddItem(recipeToCraft.itemToCraft, 1);
            for (int i = 0; i < recipeToCraft.ingredients.Count; i++)
            {
                inventoryManager.RemoveItem(recipeToCraft.ingredients[i].itemNeeded, recipeToCraft.ingredients[i].quantityNeeded);
            }
        }
    }

    bool CheckIfCanCraft()
    {
        bool itemChecked = false;
        for (int i = 0; i < recipeToCraft.ingredients.Count; i++)
        {
            for (int j = 0; j < inventoryManager.inventory.Count; j++)
            {
                if (recipeToCraft.ingredients[i].itemNeeded.itemId == inventoryManager.inventory[j].itemId)
                {
                    itemsHave++;
                    if (inventoryManager.inventory[j].quantity >= recipeToCraft.ingredients[i].quantityNeeded && !itemChecked)
                    {
                        quantitiesHave++;
                        itemChecked = true;
                    }
                }
            }
            itemChecked = false;
        }

        if (itemsHave == recipeToCraft.ingredients.Count && quantitiesHave == recipeToCraft.ingredients.Count)
        {
            quantitiesHave = 0;
            itemsHave = 0;
            return true;
        }
        else
        {
            quantitiesHave = 0;
            itemsHave = 0;
            return false;
        }
    }
}
