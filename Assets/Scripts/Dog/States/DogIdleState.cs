using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogIdleState : DogBaseState
{
    public override void EnterState(DogStateController dog)
    {
        Debug.Log("entering idle state");
    }

    public override void ExitState(DogStateController dog)
    {
        Debug.Log("exiting idle state");
    }

    public override void UpdateState(DogStateController dog)
    {
    }
    public override void FixedUpdateState(DogStateController dog)
    {

    }
}
