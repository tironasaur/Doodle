using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    public GameObject[] lifes;
    public int life;

    private void Update()
    {
        if (life < 1)
        {
            Destroy(lifes[0].gameObject);
        }
    }
}
