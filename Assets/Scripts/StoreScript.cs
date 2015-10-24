using UnityEngine;
using System.Collections;
using Image = UnityEngine.UI.Image;
using UnityEngine.UI;


public class StoreScript : MonoBehaviour
{
    /*FIRECRACKER,*//* TOILET_PAPER, YELLOW_EGG, SHIT_EGG, SHADE_EGG, SEA_EGG, RED_EGG, PURPLE_EGG, PINK_EGG, LIGHT_PURPLE_EGG, LIGHT_GREEN_EGG, LIGHT_BLUE_EGG, GREY_EGG, GOLDEN_EGG, CLEAR_GREEN_EGG, BLUE_EGG, BLACK_EGG,*//* NINJASTAR, NINJASTAR2, NINJASTAR3, NINJASTAR4, NINJASTAR5, NINJASTAR6, NINJASTAR7, NINJASTAR8,*/
    int run = 2;
    enum SALE_ITEMS { WEREWOLF, DEVIL, NUN, HOCKEY, TROLL, CANDY_APPLE, PIE, BAT, BOXING, CANDY_HOOK, CANDY_SWORD, GREAT_AXE, HOOK, KATANA, HULK_FIST, NUNCHUCKS, SCYTHE, ZOMBIE_ARM, NUM_MAX };
    //[SerializeField]
    //SALE_ITEMS typeID;
    [SerializeField]
    int selected = 0;
    [SerializeField]
    bool[] purchased;
    [SerializeField]
    GameObject[] sale_items;

    // Use this for initialization
    void Start()
    {
        transform.GetChild(0).GetComponent<Image>().enabled = true;
        transform.GetChild(1).GetComponent<Image>().enabled = false;
        transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().enabled = false;
        for (int i = 2; i <= 4; i++)
        {
            transform.GetChild(i).GetComponent<Image>().enabled = false;

            transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().enabled = false;
            transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().enabled = false;
            transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().enabled = false;
            transform.GetChild(i).transform.GetChild(3).GetComponent<Text>().enabled = false;

        }
        
        purchased = new bool[3];
        sale_items = new GameObject[(int)SALE_ITEMS.NUM_MAX];

        //sale_items[0] =

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).GetComponent<Image>().enabled == true && run < 0)
        {
            transform.GetChild(0).GetComponent<Image>().enabled = false;
            transform.GetChild(1).GetComponent<Image>().enabled = true;
            transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().enabled = true;
            for (int i = 2; i <= 4; i++)
            {
                transform.GetChild(i).GetComponent<Image>().enabled = true;

                transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().enabled = true;
                transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().enabled = true;
                transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().enabled = true;

            }

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
