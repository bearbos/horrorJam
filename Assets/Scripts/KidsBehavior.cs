using UnityEngine;
using System.Collections;

public class KidsBehavior : MonoBehaviour
{
    int playerWantedLevel = 0;
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
    // Use this for initialization
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
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
                }
                else if (player.transform.position.x < transform.position.x)
                {
                    runDirection.x = 1;
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
                Vector2 rb = GetComponent<Rigidbody2D>().velocity;
                rb = new Vector2(runDirection.x * runSpeed, runDirection.y * runSpeed);
            }
        }
        else
        {
            run = false;
        }
    }
    void Death()
    {
        int spawnedNum = Random.Range(0, 3);
        for (int i = 0; i <= spawnedNum; i++)
        {
            GameObject summonedCandy = Instantiate(candy[Random.Range(0, candy.Length)]);
            Vector2 pos = summonedCandy.transform.position;
            pos.x += Random.Range(-1, 1);
            pos.y += Random.Range(-1, 1);
            summonedCandy.transform.position = pos;
        }
        Destroy(gameObject);
    }
}
