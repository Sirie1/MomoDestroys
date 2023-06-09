using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] bool isGrounded;
    [SerializeField] float radiousCheck;
    [SerializeField] LayerMask platformLayerMask;

    public bool IsGrounded
    {
        get { return isGrounded; }
    }
    private void FixedUpdate()
    {
        GroundCheckM();
    }

    /// <summary>
    /// Generates bubble colliders with certain radius and checks for collition to certain layer
    /// </summary>
    public void GroundCheckM()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radiousCheck, platformLayerMask);
        if (colliders.Length > 0)
            isGrounded = true;
    }
}
