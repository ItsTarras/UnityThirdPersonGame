using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    // Start is called before the first frame update

    //The character follow object for the camera to follow.
    public GameObject followTarget;

    //The mouse sensitivity for the camera.
    [SerializeField]
    private float rotationPower;

    //The clamp for the minimum Y angle.
    [SerializeField]
    private float minYAngle = -90f;

    //The clamp for the maximum Y angle.
    [SerializeField]
    private float maxYAngle = 90f;


    [SerializeField]
    private GameObject PlayerModel;

    // Store the initial rotation of the camera
    private Quaternion currentRotation;

    void Start()
    {
        // Store the initial rotation of the camera
        currentRotation = transform.rotation;
    }

    private void Update()
    {
        // Move the player based on the rotation power.
        float mouseX = rotationPower * Input.GetAxis("Mouse X");
        float mouseY = rotationPower * Input.GetAxis("Mouse Y");

        // Apply rotation to the camera based on the input
        transform.Rotate(Vector3.up, mouseX, Space.World);  // Horizontal rotation
        transform.Rotate(Vector3.right, mouseY, Space.Self); // Vertical rotation

        //Move the player model rotation to face where the camera is.
        PlayerModel.transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);



        // Reset the Z-axis rotation to zero
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0f);

        // Calculate the clamped angle:
        float clampedAngle = ClampAngle(transform.localEulerAngles.x, minYAngle, maxYAngle);

        // Calculate and change the angle of the follow target.
        transform.localRotation = Quaternion.Euler(clampedAngle, transform.localEulerAngles.y, 0f);
    }

    // Clamp an angle between a minimum and maximum value
    private float ClampAngle(float angle, float min, float max)
    {
        angle = angle > 180f ? angle - 360f : angle;
        return Mathf.Clamp(angle, min, max);
    }
}
