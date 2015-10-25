using UnityEngine;
using System.Collections;

public class SnowScript : MonoBehaviour
{

    float angle;
    Quaternion rotation;
    float speed;
    float lifeSpan;
    float lifeTime;
    

    // Use this for initialization
    void Start()
    {

        angle = 5;
        rotation = new Quaternion(0, 0, angle, 90);
        speed = Random.Range(1.0f, 10.0f);
        
        lifeTime = 0.0f;
        transform.rotation = rotation;
       

    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime <= 0.9f)
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
           


        }
        else
        {
            Destroy(gameObject);
        }

    }
}
