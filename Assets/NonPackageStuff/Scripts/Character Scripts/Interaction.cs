using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool isInteracting;

    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        direction = transform.forward;
    }

    private void Update()
    {
        runInteraction();
    }

    void runInteraction()
    {
        // Bit shift the index of the layer (6) to get a bit mask
        //int layerMask = 1 << 6;

        // This would cast rays only against colliders in layer 6.
        // But instead we want to collide against everything except layer 6. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;


        //Make a raycast hit detector variable.
        RaycastHit hit;

        //Make a new ray, originating at the unity object, and aiming forwards.
        Ray ray = new Ray(transform.position, transform.forward);

        //Raycasting to check if an interactible is in front of the object.
        if (Physics.Raycast(ray, out hit, 5f))
        {
            isInteracting = true;
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
            Debug.Log("Hit an object");
        }
        else
        {
            isInteracting = false;
            Debug.DrawRay(transform.position, transform.forward * 100, Color.white);
            Debug.Log("Did not Hit");
        }
    }

}
