using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    //[SerializeField] int poopDamage;
    [SerializeField] GameObject objectPooped;
    /*//Future implementation
    public int PoopDamage
    {
        get { return poopDamage; }
        set { poopDamage = value; }
    }*/
    public GameObject ObjectPooped
    {
        get { return objectPooped; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == ObjectPooped)
            return;
        else
        {
            objectPooped = collision.gameObject;
            if (objectPooped != null)
                ScoreManager.Instance.AddPoopCollision(this);
        }


        //Debug.Log("Pooped on " + collision.gameObject.name);
    }
}
