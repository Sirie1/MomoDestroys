using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPeeState : DogBaseState
{
    float peeTimer;
    public override void EnterState(DogStateController dog)
    {
        Debug.Log("entering pee state");
        if (dog.peeController.IsPeeAvailable)
        {
            dog.animator.Play("Dog_Pee");
            peeTimer = 0;
        }
        else
        {
            Debug.Log("Not Pee Available");
            dog.SwitchState(dog.PrevState);
        }

    }

    public override void ExitState(DogStateController dog)
    {
        Debug.Log("exiting pee state");
        //dog.animator.StopPlayback();
    }

    public override void UpdateState(DogStateController dog)
    {
        peeTimer += Time.deltaTime;
        if (peeTimer > dog.peeController.PeeTime)
        {
            dog.peeController.Pee();
            dog.SwitchState(dog.PrevState);
        }
    }
    public override void FixedUpdateState(DogStateController dog)
    {

    }
}