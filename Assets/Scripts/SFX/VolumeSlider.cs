using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    void OnEnable()
    {
        SoundManager.Instance.ChangeMasterVolume(slider.value);
        slider.onValueChanged.AddListener (val => SoundManager.Instance.ChangeMasterVolume (val));
    }

}
