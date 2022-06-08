using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGoals
{
    public enum ETypeGoal
    {
        LeftGoal,
        RightGoal
    }

    public interface IGoal
    {
        ETypeGoal GetGoal();
    }
}

public class Goal : MonoBehaviour, MyGoals.IGoal
{
    [SerializeField] MyGoals.ETypeGoal typeGoal;

    public MyGoals.ETypeGoal GetGoal()
    {
        return typeGoal;
    }
}
