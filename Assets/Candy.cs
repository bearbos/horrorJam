using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour
{
    [SerializeField]
    int scoreGiven;
    [SerializeField]
    int candyGiven;
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

            Destroy(gameObject);
        }
    }
    void NoGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
