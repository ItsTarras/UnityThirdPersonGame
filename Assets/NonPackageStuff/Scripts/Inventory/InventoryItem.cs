using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InventoryItem
{
    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set; }


    //A default constructor for the class.
    public InventoryItem(InventoryItemData source)
    {
        data = source;
        AddToStack();
    }


    //Add an item to the stack.
    public void AddToStack()
    {
        stackSize++;
    }


    //Remove an item from the stack.
    public void RemoveFromStack()
    {
        stackSize--;
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
