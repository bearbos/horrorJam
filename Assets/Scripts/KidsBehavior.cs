using UnityEngine;
using System.Collections;

public class KidsBehavior : MonoBehaviour
{
    int playerWantedLevel;
    bool run;
    float runChance;
    GameObject player;
    [SerializeField]
    float runSpeed;
    Vector2 runDirection;
    [SerializeField]
    float runDistance;
    [SerializeField]
    GameObject[] candy;
    bool facingRight = true;
    int currHP;
    int maHP;
    public int minCandy = 3;
    public int maxCandy = 5;
    bool dead = false;
    // Use this for initialization
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerWantedLevel = (int)player.GetComponent<playerStats>().notoriety;
        }
        
        switch (playerWantedLevel)
        {
            case 0:
                runChance = 0;
                break;
            case 1:
                runChance = 0;
                break;
            case 2:
                runChance = 0.31f;
                break;
            case 3:
                runChance = 0.31f;
                break;
            case 4:
                runChance = 0.61f;
                break;
            case 5:
                runChance = 0.61f;
                break;
            default:
                break;
        }
        //Invoke("Death", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            Vector3 pos = transform.position;
            pos.z = transform.position.y;
            transform.position = pos;
            if (Vector2.Distance(transform.position, player.transform.position) <= runDistance)
            {
                if (Random.value < runChance && !run)
                {
                    run = true;
                }
                if (run)
                {
                    if (GetComponent<Animator>() != null)
                    {
                        GetComponent<Animator>().SetBool("running", true); 
                    }
                    if (player.transform.position.x > transform.position.x)
                    {
                        runDirection.x = -1;
                        if (facingRight)
                        {
                            Flip();
                        }
                    }
                    else if (player.transform.position.x < transform.position.x)
                    {
                        runDirection.x = 1;
                        if (!facingRight)
                        {
                            Flip();
                        }
                    }
                    else
                    {
                        runDirection.x = 0;
                    }
                    if (player.transform.position.y > transform.position.y)
                    {
                        runDirection.y = -1;
                    }
                    else if (player.transform.position.y < transform.position.y)
                    {
                        runDirection.y = 1;
                    }
                    else
                    {
                        runDirection.y = 0;
                    }
                }
            }
            else
            {
                run = false;
                runDirection = Vector2.zero;
                if (GetComponent<Animator>() != null)
                {
                    GetComponent<Animator>().SetBool("running", false); 
                }
            }
            Vector2 rb = GetComponent<Rigidbody2D>().velocity;
            rb = new Vector2(runDirection.x * runSpeed, runDirection.y * runSpeed);
            GetComponent<Rigidbody2D>().velocity = rb;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }
    }
    void Death()
    {
        int spawnedNum = Random.Range(minCandy, maxCandy);
        //Debug.Log(spawnedNum);
        for (int i = 0; i < spawnedNum; i++)
        {
            GameObject summonedCandy = Instantiate(candy[Random.Range(0, candy.Length)]);
            summonedCandy.transform.position = transform.position;
            Rigidbody2D candyRB = summonedCandy.GetComponent<Rigidbody2D>();
            int xVel = 0;
            if (facingRight)
            {
                xVel = Random.Range(2, 7);
            }
            else if (!facingRight)
            {
                xVel = Random.Range(-7, -2);
            }
            candyRB.velocity = new Vector2(xVel, Random.Range(5, 10));
            candyRB.gravityScale = 1.5f;
        }
        dead = true;
        GetComponent<SpriteRenderer>().color = Color.gray;
        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().enabled = false;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        transform.localScale = scale;
    }
}
