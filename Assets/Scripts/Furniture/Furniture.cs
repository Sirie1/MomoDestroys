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
    [SerializeField] ObjectTypes objectType;
    [SerializeField] Slider slider;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SpriteRenderer brokenSpriteRenderer;

    [SerializeField] FurnitureSO furnitureSO;

    #region Properties

    public ObjectTypes ObjectType
    {
        get { return objectType; }
    }

    #endregion
    public enum ObjectTypes
    {
        Table,
        Bench,
        Bed,
        Picture, 
        ArtPicture,
        Other
    }
    private void Start()
    {
        RestoreHealth();
        isShakeOn = false;
        shakeIntensity = 0.025f;
        shakeSpeed = 40f;
        //Set values from SO
        SetPhysics();
    }
    private void Update()
    {

        //Shake
        if (isShakeOn)
        {
            shakeCurrentTime -= Time.deltaTime;
            if (shakeCurrentTime > 0)
            {
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
    void SetPhysics()
    {

        if (furnitureSO.IsMovable)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Rigidbody2D>().mass = furnitureSO.Mass;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
    private void StartShakeTimer()
    {
        shakeCurrentTime = shakeTime;
    }
    private void ShakeFrame()
    {
        spriteRenderer.transform.localPosition = new Vector3( Mathf.Sin(Time.time * shakeSpeed) * shakeIntensity, Mathf.Sin(Time.time * shakeSpeed) * shakeIntensity, 0);
    }
    /*
    private void ResetPosition ()
    {
        isShakeAnimOn = false;
        transform.localPosition = originalPosition;

    }*/
    public string GetName()
    {
        return furnitureSO.FurnitureName;
    }
    private void RestoreHealth()
    {
        health = furnitureSO.MaxHealth;
        slider.value = 1f;
        UpdateSprite();
    }

    public void TakeDamage (float chewPower)
    {
        if (health>0)
        {
            StartShake();
            health -= chewPower * Time.deltaTime;
            ScoreManager.Instance.AddScore();
            slider.value = health /furnitureSO.MaxHealth;
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
