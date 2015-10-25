using UnityEngine;
using System.Collections;

public class PressStart : MonoBehaviour {

    Color colorOff;
    Color colorOn;

    public float theTimer = 0.0f;
    bool setColor = true;

    // Use this for initialization
    void Start()
    {
        colorOff = new Color(0, 0, 0, 0);
        colorOn = new Color(1, 1, 1, 1);

        gameObject.GetComponent<TextMesh>().color = colorOff;
    }

    // Update is called once per frame
    void Update()
    {
        theTimer += Time.deltaTime;

        if (theTimer >= 70.60f && setColor)
        {
            gameObject.GetComponent<TextMesh>().color = colorOn;
        }
        if (Input.GetButtonDown("Start Button"))
        {
            Application.LoadLevel(0);
        }
    }
}
