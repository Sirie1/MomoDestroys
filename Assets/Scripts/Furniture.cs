using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Furniture : MonoBehaviour
{
   // [SerializeField] bool mouthContact = false;
    [Range(0.0f, 100.0f)] [SerializeField] private float health = 100f;
    [SerializeField] Slider slider;
    private void Start()
    {
        RestoreHealth();
    }
    private void RestoreHealth()
    {
        health = 100f;
        slider.value = health/100;

    }

    public void TakeDamage (float chewPower)
    {
        if (health>0)
        {
            health -= chewPower * Time.deltaTime;
            ScoreManager.Instance.AddScore();
            slider.value = health / 100;
        }


    }
}
