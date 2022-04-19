using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private void Start()
    {
        movespeed = PlayerPrefs.GetFloat("newsidespeed", 5);
    }
    
    public static PlayerManager instance
    {
        get;
        private set;
    }
    private void Awake()
    {
        movespeed = PlayerPrefs.GetFloat("newsidespeed");
        
        instance = this;
    }
    public float movespeed
    {
        set;
        get;
    }

   
}
