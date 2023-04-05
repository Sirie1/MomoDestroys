using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    [SerializeField] int poopDamage;

    public int PoopDamage
    {
        get { return poopDamage; }
        set { poopDamage = value; }
    }
}
