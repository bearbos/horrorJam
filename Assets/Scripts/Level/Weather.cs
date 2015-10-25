using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour
{

    [SerializeField]
    GameObject rain;
    [SerializeField]
    GameObject snow;
    [SerializeField]
    GameObject lightning;
    [SerializeField]
    AudioSource rainSFX;
    [SerializeField]
    AudioSource lightningSFX;
    int effect;
    float offsetX;
    float offsetY;
    Vector3 position;
    float timer = 0.0f;
    int wtf;
    float idk;
    // Use this for initialization
    void Start()
    {
        idk = Random.Range(4.0f, 10.0f);
        rainSFX.volume = lightningSFX.volume = 10;
    }

    // Update is called once per frame
    void Update()
    {
        effect = 1;
        if (effect == 0)
        {
            rainSFX.Stop();
        }
        else if (effect == 1)
        {
            timer += Time.deltaTime;
            wtf = (int)GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>().notoriety;
            if (wtf == 5)
            {
                wtf *= 5;
            }
            for (int i = 0; i < wtf; i++)
            {

                if (!rainSFX.isPlaying)
                    rainSFX.Play();
                position = Camera.main.transform.position;
                position.z = 1;
                offsetX = Random.Range(-16.0f, 16.0f);
                offsetY = Random.Range(-10.0f, 10.0f);
                position.x += offsetX;
                position.y += offsetY;
                if (Time.timeScale > 0)
                    Instantiate(rain, position, rain.transform.rotation);
                if (timer >= idk)
                {
                    idk = Random.Range(4.0f, 10.0f);
                    position = Camera.main.transform.position;
                    position.z = -8;
                    if (!lightningSFX.isPlaying)
                        lightningSFX.Play();
                    Instantiate(lightning, position, lightning.transform.rotation);
                    timer = 0.0f;
                }
            }
        }
        if (wtf == 5)
        {
            //rainSFX.Stop();
            for (int i = 0; i < 3; i++)
            {

                position = Camera.main.transform.position;
                position.z = 1;
                offsetX = Random.Range(-16.0f, 16.0f);
                offsetY = Random.Range(-10.0f, 10.0f);
                position.x += offsetX;
                position.y += offsetY;
                Instantiate(snow, position, rain.transform.rotation);
            }
        }
    }
}

