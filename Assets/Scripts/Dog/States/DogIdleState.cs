using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogIdleState : DogBaseState
{
    public override void EnterState(DogStateController dog)
    {
        // Debug.Log("entering idle state");
        dog.CurrentStateName = DogStateController.StatesName.Idle;
        dog.UpdateAnimation();
    }

    public override void ExitState(DogStateController dog)
    {
        //Debug.Log("exiting idle state");
    }

    public override void UpdateState(DogStateController dog)
    {
        Vector2 input = dog.playerInput.actions["Move"].ReadValue<Vector2>();

        if (input.x != 0 && dog.IsOnGround)
        {
            dog.SwitchState(dog.WalkState);
        }
        else if (dog.playerInput.actions["Jump"].triggered && dog.IsOnGround)
        {
            dog.SwitchState(dog.JumpState);
        }
        else if (dog.playerInput.actions["Chew"].triggered && dog.mouthController.IsFurnitureReachable)
        {
            dog.SwitchState(dog.ChewState);
        }
        else if (dog.playerInput.actions["Pee"].IsPressed())
        {
            dog.SwitchState(dog.PeeState);
        }
    }
    public override void FixedUpdateState(DogStateController dog)
    {

    }
}
