using UnityEngine;
using System.Collections;

public class Dynamic_Camera : MonoBehaviour {

    // Reference to the player
    GameObject thePlayer;
   
    public GameObject theSpawner;
    bool initCamera = true;

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
        if(initCamera == true)
        {
            Vector3 newCamPos = new Vector3(0, 0, -10);
            gameObject.transform.position = newCamPos;
            initCamera = false;
        }

        gameTime += Time.deltaTime;
       
        Vector3 newPos = gameObject.transform.position;
        newPos.x += 20.0f;
        theSpawner.gameObject.transform.position = newPos;

        // Clean up old shit
        if (gameTime >= 1.0f)
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

        for (int i = 0; i < oldObjectsLength; i++)
        {
            if (oldObjects[i].transform.position.x <= (GameObject.FindWithTag("MainCamera").transform.position.x - 70.0f))
            {
                GameObject deleteThis = oldObjects[i];
                if (deleteThis.gameObject.tag == "Director" || deleteThis.gameObject.tag == "storeCanvas")
                {
                       
                }
                else
                    Destroy(deleteThis);
            }
        }
    }
}
