using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Furniture : MonoBehaviour
{
   // [SerializeField] bool mouthContact = false;
    [Range(0.0f, 100.0f)] [SerializeField] private float health = 100f;
    [SerializeField] float shakeIntensity = 0.05f;
    //[SerializeField] float shakeSpeed = 5f;
    [SerializeField] bool isShakeOn;
    [SerializeField] bool isShakeAnimOn;
    [SerializeField] Slider slider;
    [SerializeField] SpriteRenderer brokenSpriteRenderer;
    Vector2 originalPosition;
    private void Start()
    {
        RestoreHealth();
        isShakeOn = false;
        originalPosition = transform.localPosition;
    }
    private void Update()
    {
        //Shake
        if(isShakeOn)
        {
            if (!isShakeAnimOn)
            {
                isShakeAnimOn = true;
                transform.DOShakePosition(0.1f, shakeIntensity).onComplete = ResetPosition;
            }
        }
        isShakeOn=false;

    }
    private void ResetPosition ()
    {
        isShakeAnimOn = false;
        transform.localPosition = originalPosition;

    }
    private void RestoreHealth()
    {
        health = 100f;
        slider.value = health/100;
        UpdateSprite();
    }

    public void TakeDamage (float chewPower)
    {
        if (health>0)
        {
            StartShake();
            health -= chewPower * Time.deltaTime;
            ScoreManager.Instance.AddScore();
            slider.value = health / 100;
            UpdateSprite();
        }
    }
    public void StartShake()
    {
        isShakeOn = true;
    }
    void UpdateSprite()
    {
        if (health < 10f)
        {
            brokenSpriteRenderer.gameObject.SetActive (true);
        }
        else
            brokenSpriteRenderer.gameObject.SetActive(false);

    }
}
