using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopController : MonoBehaviour
{
    [SerializeField] float poopReady;

    public float PoopReady
    {
        get { return poopReady; }
        set { poopReady = value; }
    }

    
}
