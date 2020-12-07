using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float maxSteerAngle = 20f;

    public Button resetButton;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
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
        WheelColliderBackLeft.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        WheelColliderBackRight.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        //controls the direction
        WheelColliderFrontLeft.steerAngle = Input.GetAxis("Horizontal") * maxSteerAngle;
        WheelColliderFrontRight.steerAngle = Input.GetAxis("Horizontal") * maxSteerAngle;
    }

    // Update is called once per frame
    void Update()
    {
        //turning the wheels
        var pos = Vector3.zero;
        var rot = Quaternion.identity;
        WheelColliderFrontLeft.GetWorldPose(out pos, out rot);
        wheelFrontLeft.rotation = rot;
        WheelColliderFrontRight.GetWorldPose(out pos, out rot);
        wheelFrontRight.rotation = rot;
    }
}
