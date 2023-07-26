using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using DG.Tweening;
public class SpinGameObject : MonoBehaviour
{
    //In stop Spin method, it can be added what to do when spin is over
    [SerializeField] GameObject goToSpin;
    //Spin period only to watch, not to modify in inspector
    [SerializeField] float spinPeriod;
    [SerializeField] float startSpinPeriod;
    [SerializeField] float endSpinPeriod;
    [SerializeField] float decreaseSpeed;
    [SerializeField] float spinTime = 3f;
    [SerializeField] float timerSpinTime;
    float nChild;
    float timerChildPeriod = 0;
    [SerializeField] bool isSpinEnabled;
    void Update()
    {

        if (isSpinEnabled)
        {
            UpdateTimers();
            if (CheckChangeChild())
            {
                ChangeToNextChild();
            }
            UpdateSpinSpeed();
            //spinPeriod *= decreaseSpeed;
            //if (spinPeriod > endSpinPeriod)
            if (timerSpinTime > spinTime)
            {
                Debug.Log ("spin finished");
                StopSpin();
            }

        }
    }
    /*
    void SetTestParamenters()
    {
        startSpinPeriod = 0.3f;
        endSpinPeriod = 3f;
        decreaseSpeed = 1.004f;
    }
    */
    private void OnEnable()
    {
        Time.timeScale = 0;
        GameManager.Instance.DisableJoystick();
        SetupNewSpin (goToSpin);
        isSpinEnabled = true;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
        GameManager.Instance.EnableJoystick();
    }

    public void StartSpin()
    {
        DisableAllChildren();
        isSpinEnabled = true;
       
    }
    public void StopSpin()
    {
        isSpinEnabled = false;
        //Do something with final result
        goToSpin.transform.GetChild (CheckActiveChild()).gameObject.GetComponent<PUSet>().SetPU();
        goToSpin.transform.GetChild(CheckActiveChild()).gameObject.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1f, 10, 1f );
        //End something to do, finally disable object
        this.gameObject.SetActive(false);
    }
    public void SetupNewSpin(GameObject go)
    {
        goToSpin = go;
        spinPeriod = startSpinPeriod;
        nChild = goToSpin.transform.childCount;
        timerChildPeriod = 0f;
        timerSpinTime = 0f;
        SetRandomChild();
    }
    public bool CheckChangeChild()
    {
        if (timerChildPeriod > (spinPeriod / nChild))
        {
            timerChildPeriod = 0;
            return true;
        }
        else
            return false;
    }
    public void ChangeToNextChild()
    {
        int currentActiveChild = CheckActiveChild();
        if (currentActiveChild == nChild - 1)
        {
            DisableAllChildren();
            EnableChild(0);
        }

        else
        {
            DisableAllChildren();
            EnableChild(currentActiveChild + 1);
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
    public void SetRandomChild()
    {
        DisableAllChildren();
        EnableChild (Random.Range (0, (int)nChild));
    }
    void UpdateSpinSpeed()
    {
        if(timerSpinTime > spinTime)
            spinPeriod = 3;
        else if (timerSpinTime > (2*spinTime/3) && (spinPeriod <= 1.3f))
            spinPeriod = 1.3f;
        else if (timerSpinTime > (1*spinTime/3) && (spinPeriod <= 0.9f))
            spinPeriod = 0.9f;
    }
    void UpdateTimers()
    {
        //timerChildPeriod += Time.deltaTime;
        // timerSpinTime += Time.deltaTime;
        timerChildPeriod += Time.unscaledDeltaTime;
        timerSpinTime += Time.unscaledDeltaTime;
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
