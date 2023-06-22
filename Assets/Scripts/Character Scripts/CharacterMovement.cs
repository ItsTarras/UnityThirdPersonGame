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
    private float jumpHeight = 5;

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
        // Convert direction into Rigidbody space.
        direction = followTarget.rotation * direction;

        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}
