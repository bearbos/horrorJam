using UnityEngine;
using System.Collections;

public class ironmanphases : MonoBehaviour {

    float timer;
    int num, counter = 0;
    bool type = false;
    bool charging = false;
    bool startattack = false;
    Animator theAnimator;
    GameObject thePlayer;
   
    float prevDis = 5;
    float DisToPlayer;


    float _X = 0;
    float _Y = 0;

    // Use this for initialization
    void Start () {
        theAnimator = gameObject.GetComponent<Animator>();
        thePlayer = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update () {
	
	}
    public void phases()
    {
        prevDis = DisToPlayer;
         DisToPlayer= Vector2.Distance(
            thePlayer.transform.position,
            gameObject.transform.position);

        

        //temp varibles for the player's and enemies's position
        float playerX = thePlayer.transform.position.x;
        float playerY = thePlayer.transform.position.y;
        float enemyX = gameObject.transform.position.x;
        float enemyY = gameObject.transform.position.y;

        if (!type)
        {
            num = Random.Range(0, 2);
            type = true;
        }

        if (num == 0)
        {
            theAnimator.SetBool("attack1", true);

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                theAnimator.SetBool("attack1", false);
                counter++;
                if(counter == 2)
                {
                    counter = 0;
                    type = false;
                }
                gameObject.GetComponent<e_StateMachine>().attacking = false;
                timer = 0;
            }

        }
        if (num == 1)
        {
          

           
            if (charging == true)
            {

                if (playerX >= enemyX)         // enemy move left
                    _X += 2;
                if (playerX <= enemyX)         // enemy move right
                    _X -= 2;
                if (playerY >= enemyY)         // enemy move down
                    _Y += 2;
                if (playerY <= enemyY)         // enemy move up
                    _Y -= 2;
                if (DisToPlayer > 3.5f)
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(_X, _Y);
               else
                {
                    if (prevDis < DisToPlayer)
                    {
                        charging = false;
                        counter++;
                       
                    }
                }

            }
            if(DisToPlayer < 6 && charging == false)
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            if (DisToPlayer >= 6 && charging == false)
            {
               
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                charging = true;
                

                if (counter >= 2)
                {
                    counter = 0;
                    num = 0;
                    gameObject.GetComponent<e_StateMachine>().attacking = false;
                }
                gameObject.GetComponent<BoxCollider2D>().enabled = true;

                _X = 0;
                _Y = 0;
            }


        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(num == 1)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.SendMessage("TakeDamage", 5);
               
               
            }

        }
    }

}
