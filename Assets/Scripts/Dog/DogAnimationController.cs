using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static DogStateController;

public class DogAnimationController : MonoBehaviour
{

    public Animator animator;
    [SerializeField] DogPUController dogPUController;
    [SerializeField] DogStateController dogStateController;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetAnimation()
    {
        //Debug.Log (dogPUController.CurrentPowerUp.ToString() + "_" + dogStateController.CurrentStateName.ToString());
        animator.Play(dogPUController.CurrentPowerUp.ToString() + "_" + dogStateController.CurrentStateName.ToString());
    }
}
