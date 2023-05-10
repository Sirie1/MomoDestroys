using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool toggleMusic, toggleFX;
    
    public void Toggle()
    {
        if (toggleFX)
            SoundManager.Instance.ToggleFX();
        if (toggleMusic)
            SoundManager.Instance.ToggleMusic();
    }
}
