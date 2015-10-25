using UnityEngine;
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
        if (Input.GetButtonDown("A"))
        {
            LaunchStore();
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

    void LaunchStore()
    {
        Time.timeScale = 0.0f;
        Input.ResetInputAxes();
        transform.GetChild(2).gameObject.SetActive(true);
		transform.GetChild (2).GetComponent<StoreScript> ().parent = this.gameObject;

    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
