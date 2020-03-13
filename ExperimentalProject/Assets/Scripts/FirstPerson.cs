using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    public float movementSpeed = 1;
    public float maxSpeed;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    float StrafeSpeed = 0.0f;
    float ForwardSpeed = 0.0f;

    void CheckKeyInput()
    {
        //forward & backwards
        if (Input.GetKey(KeyCode.W))
        {
            ForwardSpeed = movementSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            ForwardSpeed = -movementSpeed;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            ForwardSpeed = 0;
        }

        //strafe
        if (Input.GetKey(KeyCode.D))
        {
            StrafeSpeed = movementSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            StrafeSpeed = -movementSpeed;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            StrafeSpeed = 0;
        }
    }

    void Start()
    {
        maxSpeed = movementSpeed * 2;
    }

    void Update()
    {
        CheckKeyInput();
        //this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(StrafeSpeed, 0, ForwardSpeed);
        transform.Translate(Time.deltaTime * StrafeSpeed, 0, Time.deltaTime * ForwardSpeed);
    }
}
