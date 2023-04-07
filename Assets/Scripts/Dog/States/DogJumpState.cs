using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogJumpState : DogBaseState
{
   // bool isJumping;
    float horizontal;
    Rigidbody2D rb;
    public override void EnterState(DogStateController dog)
    {
       // isJumping = true;
        rb = dog.GetComponent<Rigidbody2D>();
        Debug.Log("entering jump state");
        rb.velocity = new Vector2(rb.velocity.x, dog.JumpForce);
    }

    public override void ExitState(DogStateController dog)
    {
       // isJumping = false;
        Debug.Log("exiting jump state");
    }

    public override void UpdateState(DogStateController dog)
    {
        if (dog.IsOnGround && rb.velocity.y == 0)
            dog.SwitchState(dog.IdleState);
        horizontal = Input.GetAxisRaw("Horizontal");
    }
    public override void FixedUpdateState(DogStateController dog)
    {
        Flip(dog);
        rb.velocity = new Vector2(horizontal * dog.WalkSpeed, rb.velocity.y);
        /*
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * dog.SustainedJump);
        }*/
/*
        if (Input.GetButtonUp("Horizontal"))
        {
            rb.velocity = new Vector2(horizontal * dog.WalkSpeed, rb.velocity.y);
        }
*/
    }
    private void Flip(DogStateController dog)
    {
        if (dog.IsFacingRight && horizontal < 0f || !dog.IsFacingRight && horizontal > 0f)
        {
            dog.IsFacingRight = !dog.IsFacingRight;
            Vector3 localScale = dog.transform.localScale;
            localScale.y *= -1f;
            dog.transform.localScale = localScale;
        }
    }
}
