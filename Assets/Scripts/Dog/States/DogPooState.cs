using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPooState : DogBaseState
{
    public override void EnterState(DogStateController dog)
    {
        // Debug.Log("entering poo state");
        // dog.animator.Play("Dog_Idle");
        dog.SetAnimation(DogStateController.StatesName.Poo);
    }

    public override void ExitState(DogStateController dog)
    {


    }

    public override void UpdateState(DogStateController dog)
    {

    }
    public override void FixedUpdateState(DogStateController dog)
    {

    }
}