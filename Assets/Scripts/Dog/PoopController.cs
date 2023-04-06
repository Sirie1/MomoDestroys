using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PoopController : MonoBehaviour
{
    [SerializeField] DogController dogController;
    [SerializeField] GameObject poopPrefab;
    [SerializeField] Slider poopBarUI;

    [SerializeField] private int currentCharge;
    [SerializeField] private int reachToPoop;
    [SerializeField] private int speedToPoop;
    [SerializeField] private int poopMoneyValue;
    [SerializeField] private int poopDamage;
    [SerializeField] private bool readyToPoop;

    [SerializeField] float poopShootX;
    [SerializeField] float poopShootY;


    private void Start()
    {
        dogController = FindObjectOfType<DogController>();
        ResetPoop();
        UpdatePoopUI();
        readyToPoop =false;
    }
    //Method of poopcharge is called when something is chewed, value o increase to be modified 
    public void PoopCharge(GameObject chewedObject)
    {
        currentCharge++;
        UpdatePoopUI();
        if (currentCharge >= reachToPoop)
            readyToPoop = true;
    }
    //Creates poop, poopshootx and y defines the shot of poop
    public void Poop()
    {
        if (readyToPoop)
        {
            GameObject newPoop;
            newPoop = Instantiate(poopPrefab);

            int dir;
            if (dogController.IsFacingRight)
                dir = -1;
            else
                dir = 1;
            newPoop.transform.position = dogController.transform.position + new Vector3(dir * 0.8f, 0, 0);
            newPoop.GetComponent<Rigidbody2D>().velocity = new Vector2(poopShootX * dir, poopShootY);
            ResetPoop();
            ScoreManager.Instance.AddPoop();
            UpdatePoopUI();
            readyToPoop = false;
        }
        else 
            Debug.Log ("Not ready to poop");

    }
    //After pooping the poop bar needs to be reseted
    private void ResetPoop()
    {
       currentCharge = 0;
       UpdatePoopUI();
    }
    private void UpdatePoopUI()
    {
        poopBarUI.value = (float)currentCharge/(float)reachToPoop;
    }
}
