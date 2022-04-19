using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (gameObject.tag == "platform" || gameObject.tag == "coins")
        {
            Destroy(gameObject);
        }
     
    }
}
