using UnityEngine;
using System.Collections;
using Image = UnityEngine.UI.Image;
using UnityEngine.UI;


public class StoreScript : MonoBehaviour {

    int run = 2;
    enum SALE_ITEMS { PLACE_ONE, PLACE_TWO, PLACE_THREE };
    [SerializeField]
    int selected = 0;
    bool[] purchased;

	// Use this for initialization
	void Start () {
        transform.GetChild(0).GetComponent<Image>().enabled = true;
        transform.GetChild(1).GetComponent<Image>().enabled = false;
        transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().enabled = false;
        transform.GetChild(2).GetComponent<Image>().enabled = false;
        transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().enabled = false;
        transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().enabled = false;
        transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().enabled = false;
        transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().enabled = false;
        transform.GetChild(3).GetComponent<Image>().enabled = false;
        transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().enabled = false;
        transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().enabled = false;
        transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().enabled = false;
        transform.GetChild(3).transform.GetChild(3).GetComponent<Text>().enabled = false;
        transform.GetChild(4).GetComponent<Image>().enabled = false;
        transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().enabled = false;
        transform.GetChild(4).transform.GetChild(1).GetComponent<Text>().enabled = false;
        transform.GetChild(4).transform.GetChild(2).GetComponent<Text>().enabled = false;
        transform.GetChild(4).transform.GetChild(3).GetComponent<Text>().enabled = false;

    }

    // Update is called once per frame
    void Update () {
        if (transform.GetChild(0).GetComponent<Image>().enabled == true && run < 0)
        {
            transform.GetChild(0).GetComponent<Image>().enabled = false;
            transform.GetChild(1).GetComponent<Image>().enabled = true;
            transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(2).GetComponent<Image>().enabled = true;
            transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().enabled = true;
            transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().enabled = true;
            transform.GetChild(3).GetComponent<Image>().enabled = true;
            transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().enabled = true;
            transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().enabled = true;
            transform.GetChild(4).GetComponent<Image>().enabled = true;
            transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(4).transform.GetChild(1).GetComponent<Text>().enabled = true;
            transform.GetChild(4).transform.GetChild(2).GetComponent<Text>().enabled = true;

        }
        else if (run > -3)
        {
           
            --run;
        }

        

        if (Input.GetAxis("Horizontal") > 0)
        {
            //Right
            if (selected == 1)
            {
                selected = 2;
            }
            else if (selected == 2)
            {
                selected = 1;
            }
            else
            {
                selected = 3;
            }

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            //Left
            if (selected == 1)
            {
                selected = 2;
            }
            else if (selected == 2)
            {
                selected = 1;
            }
            else
            {
                selected = 3;
            }
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            // Up
            if (selected == 1)
            {
                selected = 3;
            }
            else if (selected == 3)
            {
                selected = 1;
            }
            else
            {
                selected = 2;
            }
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            // Down
            if (selected == 1)
            {
                selected = 3;
            }
            else if (selected == 3)
            {
                selected = 1;
            }
            else
            {
                selected = 2;
            }
        }


        for (int i = 1; i < 4; i++)
        {
            if (i == selected)
            {
                transform.GetChild(i).GetComponent<Image>().color = Color.yellow;
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().color = Color.black;
            }
        }

        if (Input.GetButtonDown("A"))
        {
            if (transform.GetChild(selected).transform.GetChild(3).GetComponent<Text>().enabled == false)
            {

            }
            else
            {
                purchased[selected - 1] = true;
                transform.GetChild(selected).transform.GetChild(3).GetComponent<Text>().enabled = true;
            }

        }

        if (Input.GetButtonDown("B"))
        {
            Time.timeScale = 1.0f;
            GameObject.FindGameObjectWithTag("Store").SendMessage("Destroy");
        }

        //transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "Testing";    //// Works
    }
}
