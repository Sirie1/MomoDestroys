using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Furniture : MonoBehaviour
{
   // [SerializeField] bool mouthContact = false;
    [Range(0.0f, 100.0f)] [SerializeField] private float health = 100f;
    [SerializeField] Slider slider;
    [SerializeField] SpriteRenderer brokenSpriteRenderer;
    private void Start()
    {
        RestoreHealth();

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
            health -= chewPower * Time.deltaTime;
            ScoreManager.Instance.AddScore();
            slider.value = health / 100;
            UpdateSprite();
        }
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
