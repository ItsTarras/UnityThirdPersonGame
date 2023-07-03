using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool isInteracting;

    private Vector3 direction;

    private InteractableItem currentInteractable; 
    
    public Inventory inventory;

    

    // Start is called before the first frame update
    void Start()
    {
        direction = transform.forward;
    }

    private void Update()
    {
        runInteraction();
        if (isInteracting)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (currentInteractable != null)
                {
                    // Add the interacted item to the inventory
                    inventory.AddItem(currentInteractable);
                    Debug.Log("Item added to inventory: " + currentInteractable.itemName);

                    // Perform any additional actions related to the interaction here

                    // Temporarily disable the object's colliders

                }
            }
        }
        
        currentInteractable = null;
    }

    void runInteraction()
    {
        //Make a raycast hit detector variable.
        RaycastHit hit;

        //Make a new ray, originating at the unity object, and aiming forwards.
        Ray ray = new Ray(transform.position, transform.forward);

        //Raycasting to check if an interactible is in front of the object.
        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.collider.tag == "Harvestable")
            {
                isInteracting = true;
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
                Debug.Log("Hit an object");

                // Get the InteractableItem component from the hit object
                currentInteractable = hit.collider.GetComponent<InteractableItem>();
            }
            else
            {
                isInteracting = false;
                Debug.DrawRay(transform.position, transform.forward * 100, Color.white);
            }
        }
        else
        {
            isInteracting = false;
            Debug.DrawRay(transform.position, transform.forward * 100, Color.white);
        }
    }


    

}
