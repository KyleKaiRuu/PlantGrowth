using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipe : MonoBehaviour
{
    [Serializable]
    public class Ingredients
    {
        public ItemData itemNeeded;
        public int quantityNeeded;
    }

    public List<Ingredients> ingredients;

    public ItemData itemToCraft;

}
