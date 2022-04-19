using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    [SerializeField] float restartdelay = 2f; //krveluc heto restart linelu jamanaky

   // [SerializeField] float sidespeed = 4.5f;

    [SerializeField] float maxposition;
    [SerializeField] Transform Player;
    [SerializeField] float ForceAcceleration = 1300f;
    [Space(20)]
    
    private Rigidbody2D rb;
    private Transform tr;
    private int distanceunit = 0; //es helac distanciayi hamar
    private float maxvelocity = 24f;

    private void Awake()
    {
       // PlayerManager.instance.movespeed = PlayerPrefs.GetFloat("newsidespeed");
       // sensitivity(PlayerPrefs.GetFloat("newsidespeed"));
    }
    private void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        tr = transform;
        SwipeController.SwipeEvent += CheckInput;
        GameManager.instance.addScore(0);
        //sidespeed = PlayerPrefs.GetFloat("newsidespeed");
        //sensitivity(PlayerPrefs.GetFloat("newsidespeed"));
    }

    private void OnDestroy()
    {
        SwipeController.SwipeEvent -= CheckInput;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (maxposition < Player.position.y)
        {
            maxposition = Player.position.y;
        }

        Invoke("distance", 0); 
        
        for (int h = 0; h < distanceunit; h += 1)
        {
           
            float gs = 0.000001f;
            if (rb.gravityScale >= 3)
                break;
            else
            {
                if (h <= distanceunit)
                {
                    rb.gravityScale += gs;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            rb.velocity = new Vector2(PlayerManager.instance.movespeed * -1, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = Vector3.zero;
            rb.velocity = new Vector2(PlayerManager.instance.movespeed, rb.velocity.y);
        }

        if (maxposition - Player.position.y > 14)
        {

            //uiobject.SetActive(true);
            //if  (life < 1)
            Invoke("restart", restartdelay);
            GameManager.instance.onGameOver?.Invoke();
            

        }

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxvelocity);//maxvelocityn ynknelu max aragutyunna
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
  
        if (rb.velocity.y <= 1)
            rb.AddForce(tr.up * rb.mass * ForceAcceleration, ForceMode2D.Impulse);
    }

    private void CheckInput(SwipeController.SwipeType type)
    {
        if (type == SwipeController.SwipeType.LEFT)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            rb.velocity = new Vector2(PlayerManager.instance.movespeed * -1, rb.velocity.y);
        }
        else if (type == SwipeController.SwipeType.RIGHT)
        {
            transform.eulerAngles = Vector3.zero;
            rb.velocity = new Vector2(PlayerManager.instance.movespeed, rb.velocity.y);
        }
    }

    private void distance()
    {
        distanceunit += 100;
        GameManager.instance.addScore(100);
    }

    private void restart()
    {
        GameManager.instance.reloadGame();
    }

    //public void sensitivity(float changedspeed)
    //{
    //    PlayerManager.instance.movespeed = changedspeed;
    //    if (changedSpeed != PlayerManager.instance.movespeed)
    //    {
    //        changedSpeed = changedspeed;
    //    }

    //}

    //public float changedSpeed
    //{
    //    get => PlayerPrefs.GetFloat("newsidespeed", PlayerManager.instance.movespeed);
    //    set => PlayerPrefs.SetFloat("newsidespeed", value);
    //}

    public void turnleft()
    {
        tr.eulerAngles = new Vector3(0, -180, 0);

        rb.velocity = new Vector2(PlayerManager.instance.movespeed * -1, rb.velocity.y);
    }

    public void turnright()
    {

        tr.eulerAngles = Vector3.zero;
        rb.velocity = new Vector2(PlayerManager.instance.movespeed, rb.velocity.y);

    }

}
