using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
  private Vector3 MovingDirection = Vector3.left; 

  void Update()
  {

  Behaviour();

  }

  void Behaviour()
  {

   if (transform.position.x > 2.5f)
   {

   MovingDirection = Vector3.left;
   gameObject.GetComponent<SpriteRenderer>().flipX = true;

   }

   else if (transform.position.x < -2.5f)
   {

   MovingDirection = Vector3.right;
   gameObject.GetComponent<SpriteRenderer>().flipX = false;

   }

   transform.Translate(MovingDirection * Time.smoothDeltaTime);

  }
   
}
