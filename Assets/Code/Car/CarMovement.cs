using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private WheelCollider wheelColliderFrontLeft;
    [SerializeField] private WheelCollider wheelColliderFrontRight;
    [SerializeField] private WheelCollider wheelColliderBackLeft;
    [SerializeField] private WheelCollider wheelColliderBackRight;

    [SerializeField] private Transform wheelFrontLeft;
    [SerializeField] private Transform wheelFrontRight;
    [SerializeField] private Transform wheelBackLeft;
    [SerializeField] private Transform wheelBackRight;

    [SerializeField] private float motorTorque = 100f;
    [SerializeField] private float maxSteerAngle = 20f;

    [SerializeField] private Transform centerOfMass;

    private Rigidbody carBody;

    public float Speed { get; private set; } = 0;

    private void Awake()
    {
        carBody = GetComponent<Rigidbody>();
        carBody.centerOfMass = centerOfMass.localPosition;
    }

    private void FixedUpdate()
    {
        // controls the speed
        wheelColliderBackLeft.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderBackRight.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        //controls the direction
        wheelColliderFrontLeft.steerAngle = Input.GetAxis("Horizontal") * maxSteerAngle;
        wheelColliderFrontRight.steerAngle = Input.GetAxis("Horizontal") * maxSteerAngle;
        //calc current speed (used for car engine sound)
        Speed = carBody.velocity.magnitude;
    }

    void Update()
    {
        //turning the wheels
        var pos = Vector3.zero;
        var rot = Quaternion.identity;
        wheelColliderFrontLeft.GetWorldPose(out pos, out rot);
        wheelFrontLeft.rotation = rot;
        wheelColliderFrontRight.GetWorldPose(out pos, out rot);
        wheelFrontRight.rotation = rot;
    }
}