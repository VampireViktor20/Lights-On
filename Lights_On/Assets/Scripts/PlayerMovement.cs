﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    bool isRunning;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed *Time.deltaTime);


        if(Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = !isRunning;
            Run();
        }
    }

    void Run()
    {
        if(isRunning)
        {
            speed = 9f;
        }
        else if(!isRunning)
        {
            speed = 6f;
        }
    }
}
