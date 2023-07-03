using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InteractableItem> items = new List<InteractableItem>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(InteractableItem item)
    {
        if (items.Contains(item))
        {
            // Increment the quantity of the existing item
            InteractableItem existingItem = items.Find(i => i.Equals(item));
            existingItem.quantity += 1;
            Debug.Log("Item already within the inventory. Adding..."); 
        }

        else
        {
            items.Add(item);
            Debug.Log("Item added to inventory: " + item.itemName);
        }
    }
}
