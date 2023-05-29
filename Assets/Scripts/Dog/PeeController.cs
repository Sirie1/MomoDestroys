using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeeController : MonoBehaviour
{

    [SerializeField] GameObject peePrefab;
    [SerializeField] int peeMaxCharge = 3;
    [SerializeField] int peeCharge = 3;
    [SerializeField] float peeTime = 2f;
    //[SerializeField] Slider peeBarUI;
    [SerializeField] bool isPeeAvailable;

    [SerializeField] PeeChargeUI peeChargeUI;

    #region GetSet

    public bool IsPeeAvailable
    {
        get { return isPeeAvailable; }
    }
    public float PeeTime
    {
        get { return peeTime; }
    }

    #endregion
    private void Start()
    {
        RestartPeeCharge();
        //peeBarUI.maxValue = peeMaxCharge;
        UpdatePeeBarUI();
        isPeeAvailable = true;
    }
    private void Update()
    {

    }
    public void Pee()
    {
        if(peeCharge>0)
        {
            GameObject newPee;
            newPee = Instantiate(peePrefab);
            newPee.transform.position = this.transform.position + new Vector3(0, -0.6f, 0);
            ScoreManager.Instance.AddPee();
            UsePeeCharge();
            UpdatePeeBarUI();
        }
        else
            Debug.Log ("Not enough pee charge");
    }

    void UsePeeCharge()
    {
        peeCharge--;
        if (peeCharge == 0)
            isPeeAvailable = false;
    }
    void RestartPeeCharge()
    {
        if (this.gameObject.tag == "Dog")
            peeChargeUI.UpdatePeeChargeUI(peeMaxCharge);
        //peeBarUI.value = peeMaxCharge;
    }
    void UpdatePeeBarUI()
    {
        //peeBarUI.value = peeCharge;
        if (this.gameObject.tag == "Dog")
            peeChargeUI.UpdatePeeChargeUI(peeCharge);
    }

}
