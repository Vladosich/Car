using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    float speed;
    float rpm;
    [SerializeField] float forcePower;
    [SerializeField ]private float turnSpeed = 40f;
    private float horizontalInput;
    private float forwardInput;

    Rigidbody playerRigidbody;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometrText;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.centerOfMass = centerOfMass.transform.position;
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        if (IsOnGround()) 
        {
            playerRigidbody.AddRelativeForce(Vector3.forward * forcePower * forwardInput);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }

        speed = Mathf.RoundToInt(playerRigidbody.velocity.magnitude * 3.6f);
        speedometrText.SetText("Speed:" + speed + "km/h");

        rpm = (speed % 30) * 40;
        rpmText.SetText("RPM:" + rpm);
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
