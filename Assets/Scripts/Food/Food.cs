using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class Food : MonoBehaviour
{
    //Box collider used for trigge, capsule collider for physics beheaviour
    //bool hasCollidedSomething;
    private Collider2D parentCollider;
    //[SerializeField] GameObject spinGO;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled=true;
       

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DelayedGroundCheck());
    }
    IEnumerator DelayedGroundCheck()
    {
        yield return new WaitForSeconds(0.1f);
        if (CheckIsGrounded())
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        parentCollider = collision;
        if (collision.gameObject.tag == "Dog"&&CheckIsGrounded())
        {
            FindObjectOfType<SpinGameObject>(true).gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

    
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision == parentCollider)
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
            GetComponent<BoxCollider2D>().enabled=false;
        }

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



}
