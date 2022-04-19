using UnityEngine;

public class Invulnerable : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    
    {

            if (collision.gameObject.name.Equals("DoodleJump"))
            {

                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<Collider2D>().enabled = false;

            }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
   
    {
        Destroy(gameObject,10);
    }
    
}
 
