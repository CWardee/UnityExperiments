using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public GameObject parentPlayerObject;

    public float movementSpeed = 5;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    float StrafeSpeed = 0.0f;
    float ForwardSpeed = 0.0f;

    bool inBuildMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (inBuildMenu)
            {
                inBuildMenu = false;
                Cursor.visible = false;
            }

            else
            {
                inBuildMenu = true;
                Cursor.visible = true;
            }
        }

        if (!inBuildMenu)
        {

            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            if (pitch < -90)
            {
                pitch = -90;
            }

            if (pitch > 90)
            {
                pitch = 90;
            }

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
            parentPlayerObject.transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

        }
    }
}
