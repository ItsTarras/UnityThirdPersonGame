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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Player Rotation
        //Move the player based on the rotation power.

        float mouseX = rotationPower * Input.GetAxis("Mouse X");
        float mouseY = rotationPower * Input.GetAxis("Mouse Y");

        // Apply rotation to the camera based on the input
        transform.Rotate(Vector3.up, mouseX * rotationPower, Space.World);  // Horizontal rotation
        transform.Rotate(Vector3.right, mouseY * rotationPower, Space.Self); // Vertical rotation

        // Reset the Z-axis rotation to zero
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        #endregion


        //Calculate the clamped angle:
        //float clampedAngle = Mathf.Clamp(transform.localEulerAngles.x, minYAngle, maxYAngle);

        //Calculate, and change the angle of the follow target.
        //transform.localRotation = Quaternion.Euler(clampedAngle, transform.localEulerAngles.y, 0f);

    }
}
