using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PeeChargeUI : MonoBehaviour
{
    [SerializeField] Image[] charge;
    [SerializeField] Color chargeColor;
    [SerializeField] Color emptyColor = Color.white;

    public void UpdatePeeChargeUI(int chargeLeft)
    {
        for(int i=0; i<charge.Count(); i++)
        {
            if (i < chargeLeft)
            {
                charge[i].color = chargeColor;
            }
            else
            {
                charge[i].color = emptyColor;
            }
        }
    }
}
