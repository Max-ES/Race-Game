using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public WheelCollider WheelColliderFrontLeft;
    public WheelCollider WheelColliderFrontRight;
    public WheelCollider WheelColliderBackLeft;
    public WheelCollider WheelColliderBackRight;

    public Transform wheelFrontLeft;
    public Transform wheelFrontRight;
    public Transform wheelBackLeft;
    public Transform wheelBackRight;

    public float motorTorque = 100f;
    public float maxSteer = 20f;
    
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void FixedUpdate()
    {
        WheelColliderBackLeft.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        WheelColliderBackRight.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        /*WheelColliderLeftFront.GetWorldPose(out pos, out rot);
        wheelLeftFront.position = pos;
        wheelLeftFront.rotation = rot;
        
        WheelColliderRightFront.GetWorldPose(out pos, out rot);
        wheelRightFront.position = pos;
        wheelRightFront.rotation = rot;*/
    }
}
