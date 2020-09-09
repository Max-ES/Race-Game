using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform centerOfMass;
    
    public WheelCollider WheelColliderFrontLeft;
    public WheelCollider WheelColliderFrontRight;
    public WheelCollider WheelColliderBackLeft;
    public WheelCollider WheelColliderBackRight;

    public Transform wheelFrontLeft;
    public Transform wheelFrontRight;
    public Transform wheelBackLeft;
    public Transform wheelBackRight;

    public float motorTorque = 100f;
    public float maxSteerAngle = 20f;

    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //_rigidbody.centerOfMass = centerOfMass.localPosition;
    }
    
    private void FixedUpdate()
    {
        // controls the speed
        WheelColliderBackLeft.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        WheelColliderBackRight.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        //controls the direction
        WheelColliderFrontLeft.steerAngle = Input.GetAxis("Horizontal") * maxSteerAngle;
        WheelColliderFrontRight.steerAngle = Input.GetAxis("Horizontal") * maxSteerAngle;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        WheelColliderFrontLeft.GetWorldPose(out pos, out rot);
        //wheelFrontLeft.position = pos;
        wheelFrontLeft.rotation = rot;
        
        WheelColliderFrontRight.GetWorldPose(out pos, out rot);
        //wheelFrontRight.position = pos;
        wheelFrontRight.rotation = rot;
    }
}
