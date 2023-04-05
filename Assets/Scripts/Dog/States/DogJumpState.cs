using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogJumpState : DogBaseState
{
    public override void EnterState(DogStateController dog)
    {
        Debug.Log("entering jump state");
    }

    public override void ExitState(DogStateController dog)
    {
        Debug.Log("exiting jump state");
    }

    public override void UpdateState(DogStateController dog)
    {
    }
    public override void FixedUpdateState(DogStateController dog)
    {

    }
}
