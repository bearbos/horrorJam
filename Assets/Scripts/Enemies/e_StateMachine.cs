using UnityEngine;
using System.Collections;

public class e_StateMachine : MonoBehaviour {

    [SerializeField]
    bool ironman;
    bool takdam;

    public bool eIdle,
         eAggro,
         eGuard;
    bool isRight;
    public bool attacking;

    float attacktimer = 0;
    float timer = 0;
    int num = 0;

    Animator theAnimator;
    GameObject thePlayer;
    


	// Use this for initialization
	void Start () {
        eIdle = true;
        eAggro = false;
        eGuard = false;
        attacking = false;
        theAnimator = gameObject.GetComponent<Animator>();
        thePlayer = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        // tracks the distance to the player's position from the Enemy's position
        float DisToPlayer = Vector2.Distance(
            thePlayer.transform.position,
            gameObject.transform.position);

        //temp varibles for the player's and enemies's position
        float playerX = thePlayer.transform.position.x;
        float playerY = thePlayer.transform.position.y;
        float enemyX = gameObject.transform.position.x;
        float enemyY = gameObject.transform.position.y;

        //if idling
        if (eIdle)
        {
            theAnimator.SetBool("run", false);

            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                if (isRight)
                {
                    theAnimator.transform.localScale = new Vector3(-1, 1, 1);
                    isRight = false;
                }
                else
                {
                    theAnimator.transform.localScale = new Vector3(1, 1, 1);
                    isRight = true;
                }
                timer = 0;
            }
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }
        //if enemy is going after the player
        if (eAggro)
        {
            if (ironman == true)
            {
                if (attacking == true)
                {
                    gameObject.SendMessage("phases");
                   

                }
                else
                {
                    theAnimator.SetBool("run", true);
                    float _X = 0;
                    float _Y = 0;
                    if (playerX >= enemyX)         // enemy move left
                        _X = 2;
                    if (playerX <= enemyX)         // enemy move right
                        _X = -2;
                    if (playerY >= enemyY)         // enemy move down
                        _Y = 2;
                    if (playerY <= enemyY)         // enemy move up
                        _Y = -2;
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(_X, _Y);
                }
                Animationflip();

            }
            else
            {
                theAnimator.SetBool("run", true);
                float _X = 0;
                float _Y = 0;
                if (playerX >= enemyX)         // enemy move left
                    _X = 2;
                if (playerX <= enemyX)         // enemy move right
                    _X = -2;
                if (playerY >= enemyY)         // enemy move down
                    _Y = 2;
                if (playerY <= enemyY)         // enemy move up
                    _Y = -2;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(_X, _Y);
                Animationflip();

                if (attacking == true)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
        }

        //if enemy is on standby ready to fight 
        if (eGuard)
        {
           
            //gameObject.SendMessage("Guard");
            float _X = 0;
            float _Y = 0;
            if (DisToPlayer >= 6)
            {
                theAnimator.SetBool("run", true);
                if (playerX >= enemyX)         // enemy move left
                    _X = 2;
                if (playerX <= enemyX)         // enemy move right
                    _X = -2;
                if (playerY >= enemyY)         // enemy move down
                    _Y = 2;
                if (playerY <= enemyY)         // enemy move up
                    _Y = -2;
            }
            if(DisToPlayer > 5 && DisToPlayer < 6)
                theAnimator.SetBool("run", false);

            if (DisToPlayer <= 5)
            {
                theAnimator.SetBool("run", true);
                if (playerX >= enemyX)         
                    _X = -2;
                if (playerX <= enemyX)         
                    _X = 2;
                if (playerY >= enemyY)         
                    _Y = -2;
                if (playerY <= enemyY)            
                    _Y = 2;
            }
            

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(_X, _Y);
            Animationflip();
        }
	
	}

    public void SetIdle()
    {
        eIdle = true;
        eAggro = false;
        eGuard = false;
    }
    public void SetAggro()
    {
        eIdle = false;
        eAggro = true;
        eGuard = false;
    }
    public void SetGuard()
    {
        eIdle = false;
        eAggro = false;
        eGuard = true;
    }

    void Animationflip()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            if (!isRight)
            {
                theAnimator.transform.localScale = new Vector3(1, 1, 1);
                isRight = true;
            }
            else 
                isRight = true;

        }
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            if (isRight)
            {
                theAnimator.transform.localScale = new Vector3(-1, 1, 1);
                isRight = false;
            }
            else
                isRight = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            theAnimator.SetBool("run", false);
            theAnimator.SetBool("attack1", true);
            attacking = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        theAnimator.SetBool("run", true);
        theAnimator.SetBool("attack1", false);
        attacking = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            theAnimator.SetBool("run", false);
            attacking = true;
        }

    }


}
