using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Furniture : MonoBehaviour
{
   // [SerializeField] bool mouthContact = false;
    [Range(0.0f, 100.0f)] [SerializeField] private float health = 100f;
    [SerializeField] float shakeIntensity = 0.025f;
    [SerializeField] float shakeTime = 0.1f;
    [SerializeField] float shakeCurrentTime = 0.1f;
    [SerializeField] float shakeSpeed = 40f;
    [SerializeField] bool isShakeOn;
    [SerializeField] bool isShakeAnimOn;
    [SerializeField] Slider slider;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SpriteRenderer brokenSpriteRenderer;
    Vector2 originalPosition;
    private void Start()
    {
        RestoreHealth();
        isShakeOn = false;
        shakeIntensity = 0.025f;
        shakeSpeed = 40f;
        originalPosition = spriteRenderer.GetComponentInParent<Transform>().position;
    }
    private void Update()
    {

        //Shake
        if (isShakeOn)
        {
            shakeCurrentTime -= Time.deltaTime;
            if (shakeCurrentTime > 0)
            {
               // isShakeAnimOn = true;
                //transform.DOShakePosition(0.1f, shakeIntensity).onComplete = ResetPosition;
                //spriteRenderer.transform.DOShakePosition(0.1f, shakeIntensity).onComplete = ResetPosition;
                ShakeFrame();
                
            }
            else
            {
                spriteRenderer.transform.localPosition = new Vector3(0, 0, 0);
                isShakeOn =false;
            }

        }
        else
            spriteRenderer.transform.localPosition = new Vector3(0, 0, 0);


    }
    private void StartShakeTimer()
    {
        shakeCurrentTime = shakeTime;
    }
    private void ShakeFrame()
    {
        spriteRenderer.transform.localPosition = new Vector3( Mathf.Sin(Time.time * shakeSpeed) * shakeIntensity, Mathf.Sin(Time.time * shakeSpeed) * shakeIntensity, 0);
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
        StartShakeTimer();
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
