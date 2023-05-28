using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimationController : MonoBehaviour
{

    public Animator animator;
    [SerializeField] DogPUController dogPUController;
    [SerializeField] DogStateController dogStateController;
    [SerializeField] string currentSkin;

    private void Awake()
    {
        //CurrentSkin set in awake before states controller calls set animation on its start
        currentSkin = "Momo_";
    }
    private void Start()
    {
        SetMomo();
    }
    public void SetAnimation()
    {
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
