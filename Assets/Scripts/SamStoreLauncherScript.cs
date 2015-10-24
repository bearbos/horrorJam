﻿using UnityEngine;
using System.Collections;

public class SamStoreLauncherScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D (Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //LaunchStore();
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }
    }

}