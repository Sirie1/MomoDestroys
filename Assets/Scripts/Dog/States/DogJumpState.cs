using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogJumpState : DogBaseState
{
    float horizontal;
    Rigidbody2D rb;

    private bool isWaitingForJump;
    
    public override void EnterState(DogStateController dog)
    {
        isWaitingForJump = true;
        SoundManager.Instance.PlayJumpSFX();
        if (dog.gameObject.tag == "Dog")
            Jump(dog);
        else if (dog.gameObject.tag == "SideDog")
            StartCoroutine (DelayedJump(dog));
        else
            Debug.LogWarning ("Trying to jump on a not valid pet");
    }

    public override void ExitState(DogStateController dog)
    {

        //Debug.Log("exiting jump state");
    }

    public override void UpdateState(DogStateController dog)
    {
        if (!isWaitingForJump)
        {
            if (dog.groundCheck.IsGrounded && Mathf.Abs(rb.velocity.y) <= Mathf.Abs(0.00001f))
            {
                if (dog.CurrentPU == DogPUController.PowerUp.Weight)
                    CinemachineShake.Instance.ShakeCamera(2f, 0.1f);
                dog.SwitchState(dog.IdleState);

                if (dog.CurrentPU == DogPUController.PowerUp.Weight && dog.groundCheck.LandedFurniture != null)
                {
                    dog.groundCheck.LandedFurniture.GetComponentInParent<Furniture>().TakeDamageFromHeavyDog(10);
                }
            }

            horizontal = dog.playerInput.actions["Move"].ReadValue<Vector2>().x;
        }

    }
    public override void FixedUpdateState(DogStateController dog)
    {
        if (!isWaitingForJump)
        {
            Flip(dog);
            rb.velocity = new Vector2(horizontal * dog.WalkSpeed, rb.velocity.y);
        }

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
    private void Jump (DogStateController dog)
    {
        rb = dog.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, dog.JumpForce);
        dog.CurrentStateName = DogStateController.StatesName.Jump;
        dog.UpdateAnimation();

        isWaitingForJump = false;
    }
    IEnumerator DelayedJump(DogStateController dog)
    {
        yield return new WaitForSeconds(0.2f);
        Jump(dog);
    }
}
