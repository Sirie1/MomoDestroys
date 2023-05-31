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
        if(this.gameObject.tag == "Dog")
            currentSkin = "Momo_";
        else if (this.gameObject.tag == "SideDog")
            currentSkin = "Tofu_";
        else
            Debug.LogWarning ("Invalid current skin set");
    }
    private void Start()
    {
        if (this.gameObject.tag == "Dog")
            SetMomo();
        else if (this.gameObject.tag == "SideDog")
            SetTofu();
        else
            Debug.LogWarning("Invalid dog set");
    }
    public void SetAnimation()
    {
        animator.Play(currentSkin + dogPUController.CurrentPowerUpSkin.ToString() + "_" + dogStateController.CurrentStateName.ToString());
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
