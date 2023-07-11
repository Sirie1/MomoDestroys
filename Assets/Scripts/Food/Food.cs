using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class Food : MonoBehaviour
{
    bool hasCollidedSomething;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckIsGrounded())
        {
            EnableFoodTrigger();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        hasCollidedSomething = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        hasCollidedSomething= false;
    }
    private bool CheckIsGrounded()
    {
        if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) <= Mathf.Abs(0.00001f))
        {
            return true;
        }
        else
            return false;
    }
    private void EnableFoodTrigger()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "dog")
        {
            Debug.Log("run pu");
            Destroy(gameObject);
        }
    }
}
