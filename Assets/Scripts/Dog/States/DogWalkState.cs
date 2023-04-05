using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWalkState : DogBaseState
{
    float horizontal;
    float speed;
    public override void EnterState(DogStateController dog)
    {
        speed = 1;
        horizontal = Input.GetAxisRaw("Horizontal");

    }

    public override void ExitState(DogStateController dog)
    {
        Debug.Log("exiting walk state");

    }

    public override void UpdateState(DogStateController dog)
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }
    public override void FixedUpdateState(DogStateController dog)
    {
        Rigidbody2D rb = dog.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
}
