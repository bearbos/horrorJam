using UnityEngine;
using System.Collections;

public class PlayerTest : MonoBehaviour {

    float theTime = 0.0f;
    Vector2 theVelocity;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        theTime += Time.deltaTime;

        if (theTime <= 7.50f)
            theVelocity = new Vector2(2, 0);
        else
            theVelocity = new Vector2(-2, 0);

        gameObject.GetComponent<Rigidbody2D>().velocity = theVelocity;

        if (theTime >= 15.0f)
            theTime = 0.0f;
    }
}
