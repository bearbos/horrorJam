using UnityEngine;
using System.Collections;
using Image = UnityEngine.UI.Image;

public class StoreScript : MonoBehaviour {

    int run = 1;

	// Use this for initialization
	void Start () {
        transform.GetChild(4).GetComponent<Image>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.GetChild(4).GetComponent<Image>().enabled == true && run < 0)
        {
            transform.GetChild(4).GetComponent<Image>().enabled = false;
            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(1).GetComponent<Image>().enabled = true;
            transform.GetChild(2).GetComponent<Image>().enabled = true;
            transform.GetChild(3).GetComponent<Image>().enabled = true;

        }
        else if (run >= 0)
        {
            --run;
        }

    }
}
