using System.Collections;
using UnityEngine;

public class GettingShield : MonoBehaviour
{
    [SerializeField] GameObject PlayerShield;

    private void Awake()
    {
        Physics2D.IgnoreLayerCollision(6, 7, false);
        PlayerShield.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("shield(Clone)"))
        {
            StartCoroutine(GetInvulnerable());
            GameManager.instance.startShield();
        }
    }
    IEnumerator GetInvulnerable()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        Physics2D.IgnoreLayerCollision(6, 7, true);
        PlayerShield.SetActive(true);
        yield return new WaitForSeconds(15f);
        PlayerShield.SetActive(false);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }

   
}
