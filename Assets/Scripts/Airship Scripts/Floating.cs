using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Floating : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float height = 1f;
    private Vector3 originalPosition;
    private float originalHeight;
    private bool isDescending = false;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalHeight = height;
    }

    // Update is called once per frame
    void Update()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        Vector3 pos = transform.position;

        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);

        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY * height, pos.z);
    }


}
