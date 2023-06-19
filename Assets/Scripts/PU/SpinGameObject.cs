using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpinGameObject : MonoBehaviour
{
    [SerializeField] GameObject goToSpin;
    [SerializeField] float spinPeriod;
    [SerializeField] float spinningDuration;
    float nChild;
    [SerializeField] float timerSpinningDuration;
    //[SerializeField] float timerOnChild;
    [SerializeField] float timerSpinPeriod;
    [SerializeField] bool isSpinEnabled;
    //[SerializeField] bool isSpinning;
   // [SerializeField] bool isTimesUpOnChild;

    // Update is called once per frame
    void Update()
    {

        if (isSpinEnabled)
        {
            UpdateTimers();
            if (CheckActiveChild() != CheckCorrespondingChildIx())
            {
                DisableAllChildren();
                EnableChild (CheckCorrespondingChildIx());
            }
            if (timerSpinningDuration > spinningDuration)
            {
                Debug.Log ("spin finished");
                StopSpin();
            }
        }
    }
    
    public void StartSpin()
    {
        DisableAllChildren();
        isSpinEnabled = true;
       
    }
    public void StopSpin()
    {
        isSpinEnabled = false;
    }
    public void SetupNewSpin(GameObject go, float newSpinDuration)
    {
        goToSpin = go;
        spinningDuration = newSpinDuration;
        nChild = goToSpin.transform.childCount;

        // timerOnChild = 0;
        timerSpinningDuration = 0;
        timerSpinPeriod = 0;
    }

    public int CheckCorrespondingChildIx()
    {
        if (timerSpinPeriod > spinPeriod)
        {
            timerSpinPeriod = 0f;
            return 0;
        }

        else
        {
            
            return Mathf.FloorToInt(timerSpinPeriod / (spinPeriod / nChild));
        }

    }
    public int CheckActiveChild()
    {
        for (int i=0; i < goToSpin.transform.childCount; i++)
        {
            if (goToSpin.transform.GetChild(i).gameObject.activeSelf)
                return i;
        }
        Debug.LogWarning ("Could not find active children");
        return 99;
    }
    void UpdateTimers()
    {
        timerSpinningDuration+= Time.deltaTime;
        timerSpinPeriod += Time.deltaTime;
    }
    void SetSpinPeriod()
    {
        //To Be completed
        spinPeriod = 0.5f;
    }
    void DisableAllChildren()
    {
        foreach (Transform child in goToSpin.transform)
        {
            child.gameObject.SetActive (false);
        }
    }
    void EnableChild(int index)
    {
        goToSpin.transform.GetChild (index).gameObject.SetActive (true);
    }
}
