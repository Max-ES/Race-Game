using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    public WheelCollider wheelColliderFrontLeft;
    public WheelCollider wheelColliderFrontRight;
    public WheelCollider wheelColliderBackLeft;
    public WheelCollider wheelColliderBackRight;

    public Transform wheelFrontLeft;
    public Transform wheelFrontRight;
    public Transform wheelBackLeft;
    public Transform wheelBackRight;

    public float motorTorque = 100f;
    public float maxSteerAngle = 20f;

    public Transform centerOfMass;

    public Button resetButton;
    private void Awake()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass.localPosition;
    }
    void Start()
    {
        resetButton.onClick.AddListener(resetCarPosition);
    }

    void resetCarPosition()
    {
        print("reset");
        Vector3 a = transform.localRotation.eulerAngles;
        a.x = 0;
        a.y = Mathf.Repeat(a.y + Input.GetAxis("Horizontal") * 5f, 360f);
        a.z = 0;
        transform.localRotation = Quaternion.Euler(a);

        transform.Translate(0, 10, 0);
    }
    
    private void FixedUpdate()
    {
        // controls the speed
        wheelColliderBackLeft.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderBackRight.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        //controls the direction
        wheelColliderFrontLeft.steerAngle = Input.GetAxis("Horizontal") * maxSteerAngle;
        wheelColliderFrontRight.steerAngle = Input.GetAxis("Horizontal") * maxSteerAngle;
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
