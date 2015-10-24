using UnityEngine;
using System.Collections;

public class BigBrother : MonoBehaviour {

    [SerializeField]
    GameObject[] candy;
    [SerializeField]
    GameObject[] weapons;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Death()
    {
        float percent = Random.value;
        Debug.Log(percent);
        if (percent < 0.02f && percent > 0)
        {
            int spawnedNum = Random.Range(0, weapons.Length);
            Debug.Log(spawnedNum);
            Instantiate(weapons[spawnedNum], transform.position, transform.rotation);
        }
        else if (percent > 0.01f && percent <= 0.31)
        {
            int spawnedNum = Random.Range(3, 5);
            Debug.Log(spawnedNum);
            for (int i = 0; i < spawnedNum; i++)
            {
                GameObject summonedCandy = Instantiate(candy[Random.Range(0, candy.Length)]);
                summonedCandy.transform.position = transform.position;
                Rigidbody2D candyRB = summonedCandy.GetComponent<Rigidbody2D>();
                int xVel = Random.Range(-7, 7);
                candyRB.velocity = new Vector2(xVel, Random.Range(5, 10));
                candyRB.gravityScale = 1.5f;
            }
        }
    }
}
