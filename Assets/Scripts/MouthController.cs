using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour
{
    [SerializeField] DogController dogController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       Debug.Log ("Entering trigger");
        if (collision.gameObject.tag == "Furniture")
        {
            dogController.IsFurnitureReachable = true;
            dogController.ReachableFurniture = collision.gameObject.GetComponentInParent<Furniture>();
        }
                
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exiting trigger");
        if (collision.gameObject.tag == "Furniture")
        {
            dogController.IsFurnitureReachable = false;
            dogController.ReachableFurniture = null;
        }
               
    }
}
