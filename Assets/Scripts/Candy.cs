using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour
{
    [SerializeField]
    int scoreGiven;
    [SerializeField]
    int candyGiven;
    public int healAmount;
    [SerializeField]
    bool heals = false;
    public int price;
    // Use this for initialization
    void Start()
    {
        Invoke("NoGravity", Random.value * .75f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerStats>().candy += candyGiven;
            other.gameObject.GetComponent<playerStats>().score += scoreGiven;
            if (heals)
            {
                other.gameObject.GetComponent<playerStats>().currHealth += healAmount;
            }
            Destroy(gameObject);
        }
    }
    void NoGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
