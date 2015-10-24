using UnityEngine;
using System.Collections;

public class RainScript : MonoBehaviour
{
    float angle;
    Quaternion rotation;
    float speed;
    float lifeSpan;
    float lifeTime;
    Animator theAnimator;

    // Use this for initialization
    void Start()
    {

        angle = 5;
        rotation = new Quaternion(0, 0, angle, 90);
        speed = Random.Range(50.0f, 60.0f);
        // lifeSpan = Random.Range(0.01f, 0.05f);
        lifeTime = 0.0f;
        transform.rotation = rotation;
        theAnimator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime <= 0.05f)
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
             theAnimator.SetBool("Dying", true);


        }
        if (lifeTime >= 5f)
        {
            Destroy(gameObject);
        }

    }
    void kill()
    {
        Destroy(gameObject);
    }
}
