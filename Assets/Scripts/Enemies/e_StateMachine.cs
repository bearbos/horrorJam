using UnityEngine;
using System.Collections;

public class e_StateMachine : MonoBehaviour {
   public bool eIdle,
         eAggro,
         eGuard;
    bool isRight;

    float timer = 0;

    Animator theAnimator;
    GameObject thePlayer;
    


	// Use this for initialization
	void Start () {
        eIdle = true;
        eAggro = false;
        eGuard = false;
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

        if (eIdle)
        {
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

        }
        if(eAggro)
        {
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
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(_X , _Y );

        }

        if (eGuard)
        {
            gameObject.SendMessage("Guard");
            float _X = 0;
            float _Y = 0;
            if (DisToPlayer >= 6)
            {
                if (playerX >= enemyX)         // enemy move left
                    _X = 2;
                if (playerX <= enemyX)         // enemy move right
                    _X = -2;
                if (playerY >= enemyY)         // enemy move down
                    _Y = 2;
                if (playerY <= enemyY)         // enemy move up
                    _Y = -2;
            }
            if (DisToPlayer <= 5)
            {
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
}
