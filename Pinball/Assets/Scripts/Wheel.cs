using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float WheelSpeed = 100;

    private Rigidbody WheelRigidbody;
    private Vector3 WheelVelocity;

    void Start()
    {
        WheelRigidbody = GetComponent<Rigidbody>();
        WheelVelocity = new Vector3(0, WheelSpeed, 0);
    }

    void FixedUpdate()
    {
        Quaternion DeltaRotation = Quaternion.Euler(WheelVelocity * Time.fixedDeltaTime);
        WheelRigidbody.MoveRotation(WheelRigidbody.rotation * DeltaRotation);
    }
}
