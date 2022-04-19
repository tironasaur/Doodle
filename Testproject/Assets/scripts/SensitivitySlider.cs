using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    void Start()
    {
        slider.value = changedSpeed;
    }
    public void sensitivity(float changedspeed)
    {
        PlayerManager.instance.movespeed = changedspeed;
        if (changedSpeed != PlayerManager.instance.movespeed)
        {
            changedSpeed = changedspeed;
        }
    }
    public float changedSpeed
    {
        get => PlayerPrefs.GetFloat("newsidespeed", PlayerManager.instance.movespeed);
        set => PlayerPrefs.SetFloat("newsidespeed", value);
    }

}
