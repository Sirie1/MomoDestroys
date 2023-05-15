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
       // Debug.Log("entering jump state");
        rb.velocity = new Vector2(rb.velocity.x, dog.JumpForce);

        //dog.SetAnimation(DogStateController.StatesName.Jump);
        dog.CurrentStateName = DogStateController.StatesName.Jump;
        dog.UpdateAnimation();
    }

    public override void ExitState(DogStateController dog)
    {
        if (dog.CurrentPU == DogPUController.PowerUp.Weight)
            CinemachineShake.Instance.ShakeCamera (2f,0.1f);
        Debug.Log("exiting jump state");
    }

    public override void UpdateState(DogStateController dog)
    {
        if (dog.groundCheck.IsGrounded && Mathf.Abs(rb.velocity.y) <= Mathf.Abs( 0.00001f))
            dog.SwitchState(dog.IdleState);
        horizontal = dog.playerInput.actions["Move"].ReadValue<Vector2>().x;
    }
    public override void FixedUpdateState(DogStateController dog)
    {
        Flip(dog);
        rb.velocity = new Vector2(horizontal * dog.WalkSpeed, rb.velocity.y);
    }

    /// <summary>
    /// Flips to the correcto facing forward position
    /// </summary>

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
