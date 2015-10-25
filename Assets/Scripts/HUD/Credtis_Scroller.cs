using UnityEngine;
using System.Collections;

public class Credtis_Scroller : MonoBehaviour {

    public float scrollSpeed;
    public float theTimer = 0.0f;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        theTimer += Time.deltaTime;

        if (theTimer <= 100.60f)
        {
            Vector3 pos = gameObject.transform.position;
            pos.y += (Time.deltaTime * scrollSpeed);
            gameObject.transform.position = pos;
        }
	}
}
