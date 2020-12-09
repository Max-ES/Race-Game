using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarMovement))]
[RequireComponent(typeof(AudioSource))]
public class CarEngine : MonoBehaviour
{
    private CarMovement car;
    private AudioSource sound;

    void Start()
    {
        car = GetComponent<CarMovement>();
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        //print(car.Speed);
        int downPitch = 1;
        float gearPitchDifference = 1f;
        if (car.Speed > 33)
        {
            downPitch = 4;
        }
        else if (car.Speed > 25)
        {
            downPitch = 3;
        }
        else if (car.Speed > 15)
        {
            downPitch = 2;
        }

        var speed = Math.Abs(car.Speed);
        float finalPitch = (float) (car.Speed * 0.2 - (downPitch - 1) * gearPitchDifference);
        sound.pitch = finalPitch > 0 ? 1 + finalPitch : 1;
    }
}