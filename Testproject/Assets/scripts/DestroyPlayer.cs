using UnityEngine;


public class DestroyPlayer : MonoBehaviour
{

    [SerializeField] GameObject enemyBloodSplash;
    public void OnCollisionEnter2D(Collision2D collision)
    {
     
        Debug.Log("kpav");
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(enemyBloodSplash, transform.position, Quaternion.identity);
            GameManager.instance.addDamage(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "enemy")
        {
            Destroy(gameObject,0.1f);
        }
    }
    
    private void restart()
    {
        GameManager.instance.reloadGame();
    }

}
