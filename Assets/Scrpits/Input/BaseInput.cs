using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyInput
{
    public struct InputData
    {
        public float movement;
    }

    public interface IInput 
    {
        InputData ProcessInput();
    }

    public abstract class BaseInput : IInput
    {
        public abstract InputData ProcessInput();
    }
}