using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DogStateController : MonoBehaviour
{
    #region Def
    public DogController dogController;
    public MouthController mouthController;   
    public PoopController poopController;
    public PeeController peeController;
    public GroundCheck groundCheck;
    public Animator animator;
    public PlayerInput playerInput;

    
    [SerializeField] bool isOnGround;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] float walkSpeed;
    [SerializeField] float sustainedJump;
    [SerializeField] float jumpForce;

    [SerializeField] DogBaseState prevState;
    [SerializeField] DogBaseState currentState;
    DogIdleState idleState = new DogIdleState();
    DogWalkState walkState = new DogWalkState();
    DogJumpState jumpState = new DogJumpState();
    DogChewState chewState = new DogChewState();
    DogPeeState peeState = new DogPeeState();
    DogPooState pooState = new DogPooState();

    #endregion

    #region States
    public DogBaseState CurrentState
    {
        get { return currentState; }
    }
    public DogBaseState PrevState
    {
        get { return prevState; }
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
    public DogPooState PooState
    {
        get { return pooState; }
    }
    public DogPeeState PeeState
    {
        get { return peeState; }
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
        get { return groundCheck.IsGrounded; }
    }

    public bool IsFacingRight
    {
        get { return isFacingRight; }
        set { isFacingRight = value; }
    }
    #endregion

    private void Start()
    {
        prevState = IdleState;
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
        prevState = currentState;
        Debug.Log ("Switching state");
        currentState.ExitState(this);

        currentState = state;
        state.EnterState(this);
    }
}
