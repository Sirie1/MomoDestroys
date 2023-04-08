using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWalkState : DogBaseState
{
    float horizontal;

    public override void EnterState(DogStateController dog)
    {
        Debug.Log("entering walk state");
        horizontal = Input.GetAxisRaw("Horizontal");
        dog.animator.Play("Dog_Walk");
    }

    public override void ExitState(DogStateController dog)
    {
        Debug.Log("exiting walk state");
       // dog.animator.StopPlayback();
    }

    public override void UpdateState(DogStateController dog)
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip(dog);
        /*
        if (Input.GetButton("Horizontal") && dog.IsOnGround)
        {
            
            horizontal = Input.GetAxisRaw("Horizontal");
        }*/

        if (Input.GetButton("Horizontal"))
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            Flip(dog);
        }
        else
            dog.SwitchState(dog.IdleState);
        if (Input.GetButton("Jump") && dog.IsOnGround)
        {
            dog.SwitchState(dog.JumpState);
        }
        else if (Input.GetButton("Fire1") && dog.mouthController.IsFurnitureReachable)
        {
            dog.SwitchState(dog.ChewState);
        }

    }
    public override void FixedUpdateState(DogStateController dog)
    {
        Rigidbody2D rb = dog.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(horizontal * dog.WalkSpeed, rb.velocity.y);
    }
    private void Flip(DogStateController dog)
    {
        if (dog.IsFacingRight && horizontal < 0f || !dog.IsFacingRight && horizontal > 0f)
        {
            dog.IsFacingRight = !dog.IsFacingRight;
            Vector3 localScale = dog.transform.localScale;
            localScale.x *= -1f;
            dog.transform.localScale = localScale;
        }
    }
}
