using UnityEngine;
using System.Collections;
using Image = UnityEngine.UI.Image;


public class titleScreen : MonoBehaviour {
    bool on = false;
    GameObject keys;



	// Use this for initialization
	void Start () {
           
        keys = GameObject.FindGameObjectWithTag("Keys");
        keys.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetButtonDown ("Start Button") || Input.GetKeyDown(KeyCode.Return))
			Application.LoadLevelAsync("MAIN_GAME");

        if (Input.GetButtonDown("Back Button") || Input.GetKeyDown(KeyCode.P))
        {
            if (on)
            {
                keys.SetActive(false);
                on = false;
                //GameObject.FindGameObjectWithTag("Title").GetComponent<Canvas>().enabled = true;

            }
            else
            {
                Application.Quit();
            }
        }
        if (Input.GetButtonDown("Y") || Input.GetKeyDown(KeyCode.K))
        {
            keys.gameObject.SetActive(true);
            on = true;
            //GameObject.FindGameObjectWithTag("Title").GetComponent<Canvas>().enabled = false;

        }
    }
}
