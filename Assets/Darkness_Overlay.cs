using UnityEngine;
using System.Collections;

public class Darkness_Overlay : MonoBehaviour {

    Color overlayCurrent;
    float currTrans = 0.0f;

	// Use this for initialization
	void Start ()
    {
        overlayCurrent = new Color(1, 1, 1, 0.0f);
        gameObject.GetComponent<SpriteRenderer>().color = overlayCurrent;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currTrans = (float)GameObject.FindWithTag("Director").GetComponent<The_Director>().streetLvl * 0.1f;

        if (currTrans >= 0.7)
            currTrans = 0.7f;

        overlayCurrent = new Color(1, 1, 1, currTrans);
        gameObject.GetComponent<SpriteRenderer>().color = overlayCurrent;
    }
    
}
