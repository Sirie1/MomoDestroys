using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DogStateController : MonoBehaviour
{
    #region Def
    public MouthController mouthController;   
    public PoopController poopController;
    public PeeController peeController;
    [SerializeField] DogAnimationController dogAnimationController;
    [SerializeField] DogPUController dogPuController; 
    public GroundCheck groundCheck;
    public PlayerInput playerInput;

    
    [SerializeField] bool isOnGround;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] float walkSpeed;
    [SerializeField] float sustainedJump;
    [SerializeField] float jumpForce;

    [SerializeField] DogBaseState prevState;
    [SerializeField] DogBaseState currentState;
    [SerializeField] StatesName currentStateName;

    DogIdleState idleState;
    DogWalkState walkState;
    DogJumpState jumpState;
    DogChewState chewState;
    DogPeeState peeState;
    DogPooState pooState;
    public enum StatesName
    {
        Idle,
        Walk,
        Jump,
        Chew,
        Poo,
        Pee
    }

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

    #region Properties

    public float WalkSpeed
    {
        get { return walkSpeed; }
        set { walkSpeed = value; }
    }
    public float JumpForce
    {
        set { jumpForce = value; }
        get { return jumpForce; }
    }
    public float SustainedJump
    {
        get { return sustainedJump; }
        set { sustainedJump = value; }
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

    public StatesName CurrentStateName
    {
        get { return currentStateName; }
        set { currentStateName = value; }
    }
    public DogPUController.PowerUp CurrentPU
    {
        get { return dogPuController.CurrentPowerUp; }
    }
    #endregion

    private void Start()
    {
        InitializeStates();
        playerInput = FindObjectOfType<PlayerInput>();
        prevState = IdleState;
        currentState = IdleState;
        currentState.EnterState(this);

        currentStateName = StatesName.Idle;
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
        //Debug.Log ("Switching state");
        currentState.ExitState(this);

        currentState = state;
        state.EnterState(this);
    }
    public void UpdateAnimation()
    {

        dogAnimationController.SetAnimation();
    }
    private void InitializeStates()
    {
        idleState = this.gameObject.AddComponent<DogIdleState>();
        walkState = this.gameObject.AddComponent<DogWalkState>();
        jumpState = this.gameObject.AddComponent<DogJumpState>();
        chewState = this.gameObject.AddComponent<DogChewState>();
        peeState = this.gameObject.AddComponent<DogPeeState>();
        pooState = this.gameObject.AddComponent<DogPooState>();

    }
}
