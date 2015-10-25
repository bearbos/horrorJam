using UnityEngine;
using System.Collections;

public class ThnksForPlying : MonoBehaviour {

    Color colorOff;
    Color colorOn;

    public float theTimer = 0.0f;
    bool setColor = true;

    // Use this for initialization
    void Start ()
    {
        colorOff = new Color(0, 0, 0, 0);
        colorOn = new Color(1, 1, 1, 1);

        gameObject.GetComponent<TextMesh>().color = colorOff;
	}
	
	// Update is called once per frame
	void Update ()
    {
        theTimer += Time.deltaTime;

        if (theTimer >= 73.60f && setColor)
        {
            gameObject.GetComponent<TextMesh>().color = colorOn;
        }
    }
}
