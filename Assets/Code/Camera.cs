using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 eulerRotation;
    [SerializeField] private float damper;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = eulerRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position + offset, damper * Time.deltaTime);
    }
}