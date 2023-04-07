using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogStateController : MonoBehaviour
{
    public DogController dogController;
    public MouthController mouthController;   
    public PoopController poopController;

    [SerializeField] bool isOnGround;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] float walkSpeed;
    [SerializeField] float sustainedJump;
    [SerializeField] float jumpForce;

    [SerializeField] DogBaseState currentState;
    DogIdleState idleState = new DogIdleState();
    DogWalkState walkState = new DogWalkState();
    DogJumpState jumpState = new DogJumpState();
    DogChewState chewState = new DogChewState();

    #region States
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
    #endregion

    #region SetGet

    public float WalkSpeed
    {
        get { return walkSpeed; }
    }
    public float JumpForce
    {
        set { jumpForce = value; }
        get { return jumpForce; }
    }
    public float SustainedJump
    {
        get { return sustainedJump; }
    }

    public bool IsOnGround
    {
        get { return isOnGround; }
    }

    public bool IsFacingRight
    {
        get { return isFacingRight; }
        set { isFacingRight = value; }
    }
    #endregion
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Furniture")
        {
            isOnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Furniture")
        {
            isOnGround = false;
        }
    }
}
