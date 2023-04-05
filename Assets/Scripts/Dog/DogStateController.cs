using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogStateController : MonoBehaviour
{
    [SerializeField] DogBaseState currentState;
    DogIdleState idleState = new DogIdleState();
    DogWalkState walkState = new DogWalkState();
    DogJumpState jumpState = new DogJumpState();
    DogChewState chewState = new DogChewState();

    public DogBaseState CurrentState
    {
        get { return currentState; }
    }
    public DogIdleState IdleState
    {
        get { return idleState; }
    }
    public DogWalkState WalkState
    {
        get { return walkState; }
    }
    public DogJumpState JumpState
    {
        get { return jumpState; }
    }
    public DogChewState ChewState
    {
        get { return chewState; }
    }

    private void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }
    public void SwitchState(DogBaseState state)
    {
        Debug.Log ("Switching state");
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }
}
