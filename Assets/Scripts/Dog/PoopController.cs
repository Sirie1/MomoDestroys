using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PoopController : MonoBehaviour
{
    [SerializeField] DogStateController dogStateController;
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


    //[SerializeField] float timeToPoop;
    //[SerializeField] float timePressed;

    private void Start()
    {
        dogStateController = FindObjectOfType<DogStateController>();
        ResetPoop();
        UpdatePoopUI();
        readyToPoop =false;
        //timeToPoop = 1f;
    }
    private void Update()
    {
        if (dogStateController.playerInput.actions["Poop"].IsPressed())
        {
            //dogStateController.animator.Play("Dog_Sit");

            //UpdatePoopTimePressed();

                
            Poop();
        }
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
        //if (readyToPoop && timePressed >= timeToPoop)
        if (readyToPoop)
        {

            GameObject newPoop;
            newPoop = Instantiate(poopPrefab);

            int dir;
            if (dogStateController.IsFacingRight)
                dir = -1;
            else
                dir = 1;
            newPoop.transform.position = dogStateController.transform.position + new Vector3(dir * 0.8f, 0, 0);
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
    /*
    //To be used if button is meant to be pressed for some seconds
    private void ResetTimePressed()
    {
        timePressed = 0f;
    }
    private void UpdatePoopTimePressed()
    {
        timePressed += Time.deltaTime;
    }*/
}
