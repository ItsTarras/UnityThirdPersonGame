using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public enum ItemType
    {
        Default,
        cookingIngredient,
        Seed,
        Weapon,
        Material,
        Tool
    }

    public ItemType itemType = ItemType.Default;
    public int quantity = 1;
    public string itemName = "Placeholder Item name";
    public string descriptionText = "Placeholder text";
    public Sprite itemSprite;
    //Add more properties here as required.

}
