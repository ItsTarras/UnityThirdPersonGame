using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryHandling : MonoBehaviour
{

    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;

    public List<InventoryItem> inventory { get; private set; }

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    /// <summary>
    /// Gets the reference data from the inventory, assuming it exists.
    /// </summary>
    /// <param name="referenceData"></param>
    /// <returns>The item of type InventoryItem.</returns>
    public InventoryItem Get(InventoryItemData referenceData)
    {
        InventoryItem value;
        if (m_itemDictionary.TryGetValue(referenceData, out value))
        {
            return value;
        }

        return null;

    }


    /// <summary>
    /// Adds an item to the inventory, assuming it already exists.
    /// </summary>
    /// <param name="referenceData"></param>
    public void Add(InventoryItemData referenceData)
    {
        InventoryItem value;
        if (m_itemDictionary.TryGetValue(referenceData, out value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
    }

    /// <summary>
    /// Remove 1 of said item from the inventory, and remove it entirely if it goes to 0 or below.
    /// </summary>
    /// <param name="referenceData"></param>
    public void Remove(InventoryItemData referenceData)
    {
        InventoryItem value;
        if (m_itemDictionary.TryGetValue(referenceData, out value))
        {
            //Remove one instance of the item.
            value.RemoveFromStack();

            //Check if there are none left.
            if (value.stackSize <= 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
