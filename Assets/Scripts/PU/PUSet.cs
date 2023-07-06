using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSet : MonoBehaviour
{
    [SerializeField] DogPUController.PowerUp PU;
    [SerializeField] GameObject dog;

    public void SetPU()
    {
        dog.GetComponent<DogPUController>().SetPU(PU);
    }
}
