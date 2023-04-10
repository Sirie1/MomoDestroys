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
        Vector2 input = dog.playerInput.actions["Move"].ReadValue<Vector2>();
        if (dog.mouthController.IsFurnitureReachable && dog.playerInput.actions["Chew"].IsPressed())
           
           // if (dog.mouthController.IsFurnitureReachable && Input.GetButton("Fire1"))
        {
            dog.mouthController.ReachableFurniture.TakeDamage(dog.mouthController.ChewPower);
            dog.poopController.PoopCharge(dog.mouthController.ReachableFurniture.gameObject);
        }
        else
            dog.SwitchState(dog.IdleState);
        if (input.x!=0 && dog.IsOnGround)
        {
            dog.SwitchState(dog.WalkState);
        }
        else if (dog.playerInput.actions["Jump"].triggered && dog.IsOnGround)
        {
            dog.SwitchState(dog.JumpState);
        }

    }
    public override void FixedUpdateState(DogStateController dog)
    {

    }
}
