using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpinGameObject : MonoBehaviour
{
    [SerializeField] GameObject goToSpin;
    [SerializeField] float spinPeriod;
    [SerializeField] float startSpinPeriod;
    [SerializeField] float endSpinPeriod;
    [SerializeField] float decreaseSpeed;
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
            spinPeriod *= decreaseSpeed;
            if (spinPeriod > endSpinPeriod)
            {
                Debug.Log ("spin finished");
                StopSpin();
            }

        }
    }
    private void OnEnable()
    {
        SetupNewSpin (goToSpin);
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
    public void SetupNewSpin(GameObject go)
    {
        goToSpin = go;
        spinPeriod = startSpinPeriod;
        nChild = goToSpin.transform.childCount;
        timerChildPeriod = 0f;
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
    void UpdateTimers()
    {
        timerChildPeriod += Time.deltaTime;
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
