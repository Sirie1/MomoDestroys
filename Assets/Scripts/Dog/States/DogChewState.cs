using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogChewState : DogBaseState
{
    public override void EnterState(DogStateController dog)
    {
        Debug.Log("entering chew state");

    }

    public override void ExitState(DogStateController dog)
    {
        Debug.Log("exiting chew state");

    }

    public override void UpdateState(DogStateController dog)
    {
    }
    public override void FixedUpdateState(DogStateController dog)
    {

    }
}
