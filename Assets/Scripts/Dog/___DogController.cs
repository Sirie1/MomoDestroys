using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DogController : MonoBehaviour
{
    #region Defs & refs
    PoopController poopController;

   // DogStateController dogStateController;

   // [SerializeField] float speed;

   // [SerializeField] float sustainedJump = 0.5f;
   // [SerializeField] float chewPower = 50f;

  //  [SerializeField] GameObject poopPrefab;

  //  [SerializeField] bool isOnGround;
    //[SerializeField] bool isFurnitureReachable = false;
   // [SerializeField] Furniture reachableFurniture;

    private float horizontal;
    //[SerializeField] private bool isFacingRight = true;
    private Rigidbody2D rb;

   // [SerializeField] float poopx;
  // [SerializeField] float poopy;
    #endregion

    #region SetGet
  /*  public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }*/
  /*
    public bool IsFurnitureReachable
    {
        get { return isFurnitureReachable; }
        set { isFurnitureReachable = value; }
    }*/

   /* public bool IsFacingRight
    {
        get { return isFacingRight; }
        set { isFacingRight = value; }
    }*/
    /*
    public Furniture ReachableFurniture
    {
        get { return reachableFurniture; }
        set { reachableFurniture = value; }
    }*/
    #endregion


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        poopController = FindObjectOfType<PoopController>();
        //dogStateController = FindObjectOfType<DogStateController>();
    }
    private void Update()
    {/*
        if (Input.GetButton("Horizontal"))
        {
            dogStateController.SwitchState(dogStateController.WalkState);
        }
        else if (dogStateController.CurrentState != dogStateController.IdleState)
            dogStateController.SwitchState(dogStateController.IdleState);

        //horizontal = Input.GetAxisRaw("Horizontal");   
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * sustainedJump);
        }
        if (Input.GetButton ("Fire1") && IsFurnitureReachable)
        {

            //Debug.Log ("Chewing");
            Chew(reachableFurniture);
        }
        if (Input.GetButtonDown("Fire3"))
        {
            Debug.Log("Pooping");
            //Debug.Log ("Chewing");
            poopController.Poop();
        }
        Flip();*/
    }
    private void FixedUpdate()
    {
        //rb.velocity = new Vector2 (horizontal*speed, rb.velocity.y);
    }
    /*private void Flip ()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;  
        }
    }*/
    #region Collisions
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Furniture")
        {
            isOnGround = true;
        }
 

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Furniture")
        {
            isOnGround = false;
        }
    }*/
    #endregion
    //For future implementations dog can chew furniture or food. 
    /*public void Chew(Furniture reachableFurniture)
    {
        if (isFurnitureReachable)
        {
            reachableFurniture.TakeDamage(chewPower);
            poopController.PoopCharge(reachableFurniture.gameObject);
        }
    }*/
    /*
    public void Poop ()
    {
        GameObject newPoop;
        newPoop = Instantiate(poopPrefab);

        int dir;
        if (isFacingRight)
            dir = -1;
        else
            dir = 1;
        newPoop.transform.position = this.transform.position + new Vector3(dir*0.8f, 0, 0);
        newPoop.GetComponent<Rigidbody2D>().velocity = new Vector2 (poopx * dir,poopy);

    }*/
}
