using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pee : MonoBehaviour
{
    [SerializeField] GameObject objectPeed;
  //  [SerializeField] Collider2D myCollider;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] RaycastHit2D[] hits = new RaycastHit2D[4];
    private void Start()
    {
        rb.Cast(-this.transform.up, hits);
        if (hits.Length > 0)
            CheckHits();
    }

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
    }

    void CheckHits()
    {
        for (int i=0; i < hits.Length; i++)
        {
            if (hits[i])
                Debug.Log ("Peed on : " + hits[i].collider.gameObject.name);
        }
    }
}
