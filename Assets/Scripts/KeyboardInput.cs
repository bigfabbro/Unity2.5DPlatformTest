using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private float MaxDoublePressTime;
    private float estimatedTime;
    private int pressJumpCounter = 0;
    // Update is called once per frame
    void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetButtonUp("Jump");
        bool runInput = Input.GetButton("Run");
        if (jumpInput)
        {
            pressJumpCounter++;
            if (pressJumpCounter == 1)
            {
                estimatedTime = Time.time + MaxDoublePressTime;
            }
            else
            {
                if (Time.time < estimatedTime)
                {
                    InputManager.Instance.roll = true;
                    InputManager.Instance.jump = false;
                }
                else
                {
                    InputManager.Instance.jump = true;
                    InputManager.Instance.roll = false;
                }
                pressJumpCounter = 0;
            }
        }
        else
        {
            if (pressJumpCounter == 1 && Time.time > estimatedTime)
            {
                InputManager.Instance.jump = true;
                pressJumpCounter = 0;
            }
            else if (pressJumpCounter == 0)
            {
                InputManager.Instance.jump = false;
            }
            InputManager.Instance.roll = false;
        }

        InputManager.Instance.run = runInput;
        InputManager.Instance.horValue = horInput;
    }
}
