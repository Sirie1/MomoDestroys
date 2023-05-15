using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pee : MonoBehaviour
{
    [SerializeField] GameObject objectPeed;

    public GameObject ObjectPeed
    {
        get { return objectPeed; }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == objectPeed)
            return;
        else
        {
            objectPeed = collision.gameObject;
            if (objectPeed != null)
                ScoreManager.Instance.AddPeeCollision(this);
        }


        //Debug.Log("Pooped on " + collision.gameObject.name);
    }
}
