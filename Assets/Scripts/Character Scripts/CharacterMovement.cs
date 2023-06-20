using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    //Coordinates of the mouse
    private float mouseX;
    private float mouseY;
    
    public float moveSpeed = 5;
    private Rigidbody rb;


    [SerializeField]
    private Rigidbody followTarget;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {
        // Convert direction into Rigidbody space.
        direction = followTarget.rotation * direction;

        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}
