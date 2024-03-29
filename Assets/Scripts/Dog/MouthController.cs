using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour
{
    [SerializeField] DogStateController dogStateController;
    [SerializeField] bool isFurnitureReachable = false;
    [SerializeField] Furniture reachableFurniture;
    [SerializeField] float chewPower = 50f;
    [SerializeField] float chewTime = 0.3f;
    [SerializeField] PoopController poopController;
    [SerializeField] Animator mouthAnimator;


    private void Start()
    {

    }
    public bool IsFurnitureReachable
    {
        get { return isFurnitureReachable; }
        set { isFurnitureReachable = value; }
    }
    public Furniture ReachableFurniture
    {
        get { return reachableFurniture; }
        set { reachableFurniture = value; }
    }
    public float ChewPower
    {
        get { return chewPower; }
    }
    public float ChewTime
    {
        get { return chewTime; }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       //Debug.Log ("Entering trigger");
        if (collision.gameObject.tag == "Furniture")
        {
            IsFurnitureReachable = true;
            reachableFurniture = collision.gameObject.GetComponentInParent<Furniture>();
        }
                
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (reachableFurniture == null)
        {
            if (collision.gameObject.tag == "Furniture")
            {
                IsFurnitureReachable = true;
                reachableFurniture = collision.gameObject.GetComponentInParent<Furniture>();
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("Exiting trigger");
        if (collision.gameObject.tag == "Furniture")
        {
            IsFurnitureReachable = false;
            reachableFurniture = null;
            mouthAnimator.SetBool("isChewing", false);
        }
               
    }
    public void StartAnimation()
    {
        mouthAnimator.SetBool("isChewing", true);
    }
    public void StopAnimation()
    {
        mouthAnimator.SetBool("isChewing", false);
    }
}
