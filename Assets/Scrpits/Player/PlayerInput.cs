using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerInput : MyInput.BaseInput
{
    public string moveInput = "Vertical";

    public override MyInput.InputData ProcessInput()
    {
        return new MyInput.InputData
        {
            movement = Input.GetAxis(moveInput)
        };
    }
}
