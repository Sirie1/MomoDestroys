using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogJumpState : DogBaseState
{
    float horizontal;
    Rigidbody2D rb;
    public override void EnterState(DogStateController dog)
    {
        rb = dog.GetComponent<Rigidbody2D>();
        Debug.Log("entering jump state");
        rb.velocity = new Vector2(rb.velocity.x, dog.JumpForce);
        dog.animator.Play("Dog_Jump");
    }

    public override void ExitState(DogStateController dog)
    {
        Debug.Log("exiting jump state");
    }

    public override void UpdateState(DogStateController dog)
    {
        if (dog.IsOnGround && rb.velocity.y == 0)
            dog.SwitchState(dog.IdleState);
        horizontal = dog.playerInput.actions["Move"].ReadValue<Vector2>().x;
    }
    public override void FixedUpdateState(DogStateController dog)
    {
        Flip(dog);
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
