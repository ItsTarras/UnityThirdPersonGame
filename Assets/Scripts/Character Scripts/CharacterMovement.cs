using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    //Coordinates of the mouse
    private float mouseX;
    private float mouseY;
    
    public float baseSpeed = 5;
    private Rigidbody rb;

    [SerializeField]
    private float descellerationLimit = 0.05f;

    [SerializeField]
    private Rigidbody followTarget;

    Vector3 movement;

    private float moveSpeed;




    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        float moveSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Detect key presses
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Running input
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = baseSpeed * 2;
        }
        else
        {
            moveSpeed = baseSpeed;
        }

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {
        // Remove the y-component of the direction vector
        direction.y = 0;

        // Convert direction into Rigidbody space.
        direction = Quaternion.Euler(0, followTarget.transform.rotation.eulerAngles.y, 0) * direction;

        // Normalize the direction vector to eliminate speed inconsistencies
        direction.Normalize();

        // Multiply the direction by moveSpeed
        Vector3 movement = direction * moveSpeed;

        // Apply the movement to the Rigidbody
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
