using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPUController : MonoBehaviour
{
    [SerializeField] PowerUPsSO normalSO;
    [SerializeField] PowerUPsSO superSO;
    [SerializeField] PowerUPsSO weightSO;

    [SerializeField] Rigidbody2D myRigidbody2D;
    [SerializeField] DogStateController dogStateController;
    [SerializeField] DogAnimationController dogAnimationController;

    [SerializeField] PowerUp currentPowerUp;

    public PowerUp CurrentPowerUp
    {
        get { return currentPowerUp; }
        set
        {
            currentPowerUp = value;
            UpdatePUStats();
            UpdatePUAnimation();

        }
    }
    public enum PowerUp
    {
        Normal,
        Super,
        Weight,
        Bite
    }

    #region Debugging power ups

    public void SetPUNormal()
    {
        CurrentPowerUp = PowerUp.Normal;
    }
    public void SetPUSuper()
    {
        CurrentPowerUp = PowerUp.Super;
    }

    public void SetPUWeight()
    {
        CurrentPowerUp = PowerUp.Weight;
    }

    #endregion
    public void UpdatePUStats()
    {
        switch (currentPowerUp)
        {
            case PowerUp.Normal:
                {
                    SetSOConfig(normalSO);
                }
                break;
            case PowerUp.Super:
                {
                    SetSOConfig(superSO);
                }
                break;
            case PowerUp.Weight:
                {
                    SetSOConfig(weightSO);
                }
                break;
            case PowerUp.Bite:
                {
                    //Needs to be created
                    Debug.LogWarning (" bite info still not created");
                    SetSOConfig(normalSO);
                }
                break;
            default:
                Debug.LogWarning("Power Up not valid");
                break;
        }
    }
    void SetSOConfig(PowerUPsSO puSO)
    {
        myRigidbody2D.mass = puSO.mass;
        dogStateController.WalkSpeed = puSO.walkSpeed;
        dogStateController.JumpForce = puSO.jumpForce;
        dogStateController.SustainedJump = puSO.sustainedJump;

    }
    void UpdatePUAnimation()
    {
        dogAnimationController.SetAnimation();
    }

}
