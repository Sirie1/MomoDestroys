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

    [SerializeField] GameObject tofuPrefab;

    [SerializeField] PowerUp currentPowerUp;
    [SerializeField] PowerUp currentPowerUpSkin;

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
    public PowerUp CurrentPowerUpSkin
    {
        get { return currentPowerUpSkin; }

    }
    public enum PowerUp
    {
        Normal,
        Super,
        Weight,
        Tofu
    }

    #region Debugging power ups

    public void SetPUNormal()
    {
        CurrentPowerUp = PowerUp.Normal;
        currentPowerUpSkin = PowerUp.Normal;
    }
    public void SetPUSuper()
    {
        CurrentPowerUp = PowerUp.Super;
        currentPowerUpSkin = PowerUp.Super;
    }

    public void SetPUWeight()
    {
        CurrentPowerUp = PowerUp.Weight;
        currentPowerUpSkin = PowerUp.Weight;
    }
    public void SetPUTofu()
    {
        CurrentPowerUp = PowerUp.Tofu;
        currentPowerUpSkin = PowerUp.Normal;
        var tofu = Instantiate(tofuPrefab);
        tofu.transform.position = this.transform.position - new Vector3 (-2,1,0);
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
            case PowerUp.Tofu:
                {
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
