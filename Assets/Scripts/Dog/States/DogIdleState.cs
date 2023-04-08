using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogIdleState : DogBaseState
{
    public override void EnterState(DogStateController dog)
    {
        Debug.Log("entering idle state");
        dog.animator.Play("Dog_Idle");
    }

    public override void ExitState(DogStateController dog)
    {
        Debug.Log("exiting idle state");
        //dog.animator.StopPlayback();
    }

    public override void UpdateState(DogStateController dog)
    {
        if (Input.GetButton("Horizontal") && dog.IsOnGround)
        {
            dog.SwitchState(dog.WalkState);
        }

        //horizontal = Input.GetAxisRaw("Horizontal");   
        else if (Input.GetButtonDown("Jump") && dog.IsOnGround)
        {
            dog.SwitchState(dog.JumpState);
        }
        else if (Input.GetButtonDown("Fire1") && dog.mouthController.IsFurnitureReachable)
        {
            dog.SwitchState(dog.ChewState);
        }
    }
    public override void FixedUpdateState(DogStateController dog)
    {

    }
}
