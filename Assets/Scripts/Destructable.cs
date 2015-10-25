using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour
{
    public float HP,pressure;
    public int score;
    //varibles for the visual feedback when the skeleton takes damage
    Color baseColor;
    bool changeColor;
    float delayColorChanger;
    [SerializeField]
    AudioSource sfx;
    [SerializeField]
    GameObject[] candy;

    // Use this for initialization
    void Start()
    {
        Vector3 newPos;
        newPos = gameObject.transform.position;
        newPos.z = newPos.y;
        gameObject.transform.position = newPos;
        baseColor = GetComponent<SpriteRenderer>().color;
        sfx.volume = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos;
        newPos = gameObject.transform.position;
        newPos.z = newPos.y;
        gameObject.transform.position = newPos;

        if (HP <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>().pressure += pressure;
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>().score += score;
            int spawnedNum = Random.Range(1, 3);
           // Debug.Log(spawnedNum);
            for (int i = 0; i < spawnedNum; i++)
            {
                GameObject summonedCandy = Instantiate(candy[Random.Range(0, candy.Length)]);
                summonedCandy.transform.position = transform.position;
                Rigidbody2D candyRB = summonedCandy.GetComponent<Rigidbody2D>();
                candyRB.velocity = new Vector2(Random.Range(-7, 7), Random.Range(5, 10));
                candyRB.gravityScale = 1.5f;
            }
            Destroy(gameObject);
        }
        if (changeColor == true)
        {
            //start the delaytimer and change the enemy's color to red
            delayColorChanger += Time.deltaTime;
            Color newColor = new Color(1.0f, 0, 0);
            gameObject.GetComponent<SpriteRenderer>().color = newColor;

            //after the color is red change the color back to its normal color
            //and change the bool back to false
            if (delayColorChanger >= 0.1f)
            {
                gameObject.GetComponent<SpriteRenderer>().color = baseColor;
                delayColorChanger = 0.0f;
                changeColor = false;
            }
        }
    }
    public void TakeDamage(float _dam)
    {
        HP -= _dam;
        changeColor = true;
        if(!sfx.isPlaying)
        {
            sfx.Play();
        }
    }
}
