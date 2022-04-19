using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldTimer : MonoBehaviour
{
    [SerializeField] Text ShieldTime;

    public bool incooldown = false;
    public float ST = 10f;

    public float timer = 15f;
    private void Start()
    {
        GameManager.instance.onGetShield += DisplayTimer;
    }

    public void DisplayTimer()
    {

        StartCoroutine(DisplayTimer1());
      
    }

IEnumerator DisplayTimer1()
 {
        timer = 15f;
    while (timer >= 0)
    {
        ShieldTime.text = "Shield Time: " + timer;
        yield return new WaitForSeconds(1f);
            timer -= 1;
    }
 }

}


