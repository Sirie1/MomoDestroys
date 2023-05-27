using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
//using static DogStateController;

public class DogAnimationController : MonoBehaviour
{

    public Animator animator;
    [SerializeField] DogPUController dogPUController;
    [SerializeField] DogStateController dogStateController;
    [SerializeField] string currentSkin;
    // Start is called before the first frame update

    private void Start()
    {
        SetMomo();
    }
    public void SetAnimation()
    {
        //Debug.Log (dogPUController.CurrentPowerUp.ToString() + "_" + dogStateController.CurrentStateName.ToString());
        animator.Play(currentSkin + dogPUController.CurrentPowerUp.ToString() + "_" + dogStateController.CurrentStateName.ToString());
    }
    public void SetMomo()
    {
        animator.StopPlayback();
        currentSkin = "Momo_";
    }
    public void SetTofu()
    {
        animator.StopPlayback();
        currentSkin = "Tofu_";
    }
}
