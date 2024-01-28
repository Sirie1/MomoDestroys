using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionController : MonoBehaviour
{
    void Awake()
    {
        GameManager.Instance.LoadDependencies();
        GameManager.Instance.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
