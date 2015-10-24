using UnityEngine;
using System.Collections;

public class Dynamic_Camera : MonoBehaviour {

    // Reference to the player
    GameObject thePlayer;

    // Camera Stuff
    Vector3 prevPos;
    Vector3 currPos;
    Vector3 newCamPos;
    float posDiff;

    float gameTime = 0.0f;

    // Data Members
    bool updateCamera = false;

	// Use this for initialization
	void Start ()
    {
        // Find the player
        if (GameObject.FindWithTag("Player"))
            thePlayer = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        gameTime += Time.deltaTime;

        // Clean up old shit
        if(gameTime >= 1.0f)
        {
            CleanUp();
        }
        // Update current position
        currPos = thePlayer.transform.position;

	    // If camera needs to move
        if(updateCamera == true)
        {
            MoveCamera();
        }

        // Update previous position
        prevPos = currPos;
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            updateCamera = true;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            updateCamera = true;
        }
    }

    void MoveCamera()
    {
        posDiff = (currPos.x - prevPos.x);

        if (posDiff >= 0.0f)
        {
            newCamPos = new Vector3(gameObject.transform.position.x + posDiff, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = newCamPos;
        }

        updateCamera = false;
    }

    void CleanUp()
    {
        // Destroy old houses
        GameObject[] oldObjects = FindObjectsOfType<GameObject>();

        int oldObjectsLength = oldObjects.Length;

        for (int i = oldObjectsLength; i > 0; i--)
        {
            if (oldObjects[i - 1].transform.position.x <= (GameObject.FindWithTag("MainCamera").transform.position.x - 70.0f))
                Destroy(oldObjects[i - 1]);
        }
    }
}
