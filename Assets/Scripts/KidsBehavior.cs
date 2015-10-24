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
    // Use this for initialization
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        playerWantedLevel = Random.Range(0, 5);
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
        if (Vector2.Distance(transform.position, player.transform.position) <= runDistance)
        {
            if (Random.value < runChance && !run)
            {
                run = true;
            }
            if (run)
            {
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
        }
        Vector2 rb = GetComponent<Rigidbody2D>().velocity;
        rb = new Vector2(runDirection.x * runSpeed, runDirection.y * runSpeed);
        GetComponent<Rigidbody2D>().velocity = rb;
    }
    void Death()
    {
        int spawnedNum = Random.Range(3, 5);
        Debug.Log(spawnedNum);
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
        Destroy(gameObject);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        transform.localScale = scale;
    }
}
