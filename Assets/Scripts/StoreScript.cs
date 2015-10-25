using UnityEngine;
using System.Collections;
using Image = UnityEngine.UI.Image;
using UnityEngine.UI;


public class StoreScript : MonoBehaviour
{
    /*FIRECRACKER,*//* TOILET_PAPER, YELLOW_EGG, SHIT_EGG, SHADE_EGG, SEA_EGG, RED_EGG, PURPLE_EGG, PINK_EGG, LIGHT_PURPLE_EGG, LIGHT_GREEN_EGG, LIGHT_BLUE_EGG, GREY_EGG, GOLDEN_EGG, CLEAR_GREEN_EGG, BLUE_EGG, BLACK_EGG,*//* NINJASTAR, NINJASTAR2, NINJASTAR3, NINJASTAR4, NINJASTAR5, NINJASTAR6, NINJASTAR7, NINJASTAR8,*/
    int run = 2;       // frames the images is displayed when the store opens.
    enum SALE_ITEMS { WEREWOLF, DEVIL, NUN, HOCKEY, TROLL, CANDY_APPLE, PIE, BAT, BOXING, CANDY_HOOK, CANDY_SWORD, GREAT_AXE, HOOK, KATANA, HULK_FIST, NUNCHUCKS, SCYTHE, ZOMBIE_ARM, NUM_MAX };
    //[SerializeField]
    //SALE_ITEMS typeID;
    [SerializeField]
    int selected = 0;     // active selected item. 0 is the flash image and 1 is the panel with Sam.
    [SerializeField]
    bool[] purchased;     // each slot, to show it is has been purchased.
    [SerializeField]
    bool[] playerHas;     //  array to track what masks the player has already.
    [SerializeField]
    GameObject[] possible_sale_items;     // array of every item possible.
    //[SerializeField]
    //GameObject[] sale_items;      // array of items for sale this iteration of the store.
    [SerializeField]
    int[] sale_items;
    [SerializeField]
    int[] itemType;         // which type of items are in each or the three sale slots. ( 0 = mask, 1 = health item, 2 = weapon)
    GameObject player;
    [SerializeField]
    int buffer = 5;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        //sale_items = new GameObject[(int)SALE_ITEMS.NUM_MAX];
        //possible_sale_items = GetComponent<StoreDatabaseScript>().storeDatabase;
        playerHas = new bool[5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (player.GetComponentInChildren<maskController>().maskCollection[i].GetComponent<Mask>().name != null)
                {
                    if (player.GetComponentInChildren<maskController>().maskCollection[i].GetComponent<Mask>().name == possible_sale_items[j].GetComponent<Mask>().name)
                    {
                        playerHas[i] = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
                

            }
        }
        sale_items = new int[3];
        itemType = new int[3];
        RollItems();

        for (int i = 2, j = 0; i <= 4; i++, j++)
        {
            switch (itemType[j])
            {
                case 0:
                    {
                        // transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = sale_items[j].GetComponent<Mask>().sprite;
                        // transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = sale_items[j].GetComponent<Mask>().description;
                        // transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = sale_items[j].GetComponent<Mask>().price.ToString();
                        //transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = GetComponent<StoreDatabaseScript>().storeDatabase[sale_items[i]].GetComponent<Mask>().sprite;
                        //transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = GetComponent<StoreDatabaseScript>().storeDatabase[sale_items[i]].GetComponent<Mask>().description;
                        //transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = GetComponent<StoreDatabaseScript>().storeDatabase[sale_items[i]].GetComponent<Mask>().price.ToString();
                        transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = possible_sale_items[sale_items[j]].GetComponent<Mask>().sprite;
                        transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = possible_sale_items[sale_items[j]].GetComponent<Mask>().description;
                        transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = possible_sale_items[sale_items[j]].GetComponent<Mask>().price.ToString();
                        break;
                    }
                case 1:
                    {
                        // transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = sale_items[j].GetComponent<SpriteRenderer>().sprite;
                        // transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = "Eat me to heal " + sale_items[j].GetComponent<Candy>().healAmount.ToString() + " points of damage.";
                        // transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = sale_items[j].GetComponent<Candy>().price.ToString();
                        //transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = GetComponent<StoreDatabaseScript>().storeDatabase[sale_items[i]].GetComponent<SpriteRenderer>().sprite;
                        //transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = "Eat me to heal " + GetComponent<StoreDatabaseScript>().storeDatabase[sale_items[i]].GetComponent<Candy>().healAmount.ToString() + " points of damage.";
                        //transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = GetComponent<StoreDatabaseScript>().storeDatabase[sale_items[i]].GetComponent<Candy>().price.ToString();
                        transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = possible_sale_items[sale_items[j]].GetComponent<SpriteRenderer>().sprite;
                        transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = "Eat me to heal " + possible_sale_items[sale_items[j]].GetComponent<Candy>().healAmount.ToString() + " points of damage.";
                        transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = possible_sale_items[sale_items[j]].GetComponent<Candy>().price.ToString();
                        break;
                    }
                case 2:
                    {
                        // transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = sale_items[j].GetComponent<weapon>().sprite;
                        // transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = sale_items[j].GetComponent<weapon>().description;
                        // transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = sale_items[j].GetComponent<weapon>().price.ToString();
                        //transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = GetComponent<StoreDatabaseScript>().storeDatabase[sale_items[i]].GetComponent<weapon>().sprite;
                        //transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = GetComponent<StoreDatabaseScript>().storeDatabase[sale_items[i]].GetComponent<weapon>().description;
                        //transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = GetComponent<StoreDatabaseScript>().storeDatabase[sale_items[i]].GetComponent<weapon>().price.ToString();
                        transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = possible_sale_items[sale_items[j]].GetComponent<weapon>().sprite;
                        transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = possible_sale_items[sale_items[j]].GetComponent<weapon>().description;
                        transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = possible_sale_items[sale_items[j]].GetComponent<weapon>().price.ToString();
                        break;
                    }
                default:
                    break;
            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (buffer > 0)
        {
            --buffer;
        }
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





        if (Input.GetAxis("Horizontal") > 0 && buffer == 0)
        {
            //Right
            if (selected == 3)
            {
                selected = 2;
            }
            else if (selected == 2)
            {
                selected = 3;
            }
            else
            {
                selected = 4;
            }
            buffer = 5;

        }
        else if (Input.GetAxis("Horizontal") < 0 && buffer == 0)
        {
            //Left
            if (selected == 3)
            {
                selected = 2;
            }
            else if (selected == 2)
            {
                selected = 3;
            }
            else
            {
                selected = 4;
            }
            buffer = 5;
        }

        if (Input.GetAxis("Vertical") > 0  & buffer == 0)
        {
            // Up
            if (selected == 3)
            {
                selected = 4;
            }
            else if (selected == 4)
            {
                selected = 3;
            }
            else
            {
                selected = 2;
            }
            buffer = 5;
        }
        else if (Input.GetAxis("Vertical") < 0 && buffer == 0)
        {
            // Down
            if (selected == 4)
            {
                selected = 3;
            }
            else if (selected == 3)
            {
                selected = 4;
            }
            else
            {
                selected = 2;
            }
            buffer = 5;
        }



        for (int i = 2; i < 4; i++)
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
            if (purchased[selected - 2] == false)
            {


                switch (itemType[selected - 2])
                {
                    case 0:
                        {
                            if (player.GetComponent<playerStats>().candy >= possible_sale_items[sale_items[selected - 2]].GetComponent<Mask>().price)
                            {
                                player.GetComponent<playerStats>().candy -= possible_sale_items[sale_items[selected - 2]].GetComponent<Mask>().price;
                                player.GetComponentInChildren<maskController>().AddAMask(possible_sale_items[sale_items[selected - 2]]);
                                purchased[selected - 2] = true;
                                transform.GetChild(selected).transform.GetChild(3).GetComponent<Text>().enabled = true;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (player.GetComponent<playerStats>().candy >= possible_sale_items[sale_items[selected - 2]].GetComponent<Candy>().price)
                            {
                                player.GetComponent<playerStats>().candy -= possible_sale_items[sale_items[selected - 2]].GetComponent<Candy>().price;
                                player.GetComponent<playerStats>().currHealth += possible_sale_items[sale_items[selected - 2]].GetComponent<Candy>().healAmount;
                                purchased[selected - 2] = true;
                                transform.GetChild(selected).transform.GetChild(3).GetComponent<Text>().enabled = true;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (player.GetComponent<playerStats>().candy >= possible_sale_items[sale_items[selected - 2]].GetComponent<weapon>().price)
                            {
                                player.GetComponent<playerStats>().candy -= possible_sale_items[sale_items[selected - 2]].GetComponent<weapon>().price;
                                Instantiate(possible_sale_items[sale_items[selected - 2]], transform.position, transform.rotation);
                                purchased[selected - 2] = true;
                                transform.GetChild(selected).transform.GetChild(3).GetComponent<Text>().enabled = true;
                            }
                            break;
                        }
                    default:
                        break;
                }

                purchased[selected - 2] = true;
                transform.GetChild(selected).transform.GetChild(3).GetComponent<Text>().enabled = true;
            }
            else
            {
                purchased[selected - 2] = true;
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

    void RollItems()
    {
        //int temp = Random.Range(0, (int)SALE_ITEMS.NUM_MAX);
        //int temp2 = Random.Range(0, (int)SALE_ITEMS.NUM_MAX);
        //int temp3 = Random.Range(0, (int)SALE_ITEMS.NUM_MAX);
        int[] temp;

        temp = new int[3];

        for (int i = 0; i < 3; i++)
        {
            temp[i] = Random.Range(0, (int)SALE_ITEMS.NUM_MAX);
        }

        if (temp[0] < 5)
        {
            while (playerHas[temp[0]])
            {
                temp[0] = Random.Range(0, (int)SALE_ITEMS.NUM_MAX);
            }
        }
        if (temp[1] < 5)
        {
            while (temp[1] == temp[0] || playerHas[temp[1]])
            {
                temp[1] = Random.Range(0, (int)SALE_ITEMS.NUM_MAX);
            }
        }
        else
        {
            while (temp[1] == temp[0])
            {
                temp[1] = Random.Range(0, (int)SALE_ITEMS.NUM_MAX);

            }
        }
        if (temp[2] < 5)
        {
            while (temp[2] == temp[1] || temp[2] == temp[0] || playerHas[temp[2]])
            {
                temp[2] = Random.Range(0, (int)SALE_ITEMS.NUM_MAX);
            }
        }
        else
        {
            while (temp[2] == temp[1] || temp[2] == temp[0])
            {
                temp[2] = Random.Range(0, (int)SALE_ITEMS.NUM_MAX);
            }
        }

        //sale_items[0] = GetComponent<StoreDatabaseScript>().storeDatabase[temp[0]];
        //sale_items[1] = GetComponent<StoreDatabaseScript>().storeDatabase[temp[1]];            // Not sure I need this
        //sale_items[2] = GetComponent<StoreDatabaseScript>().storeDatabase[temp[2]];

        sale_items[0] = temp[0];
        sale_items[1] = temp[1];
        sale_items[2] = temp[2];


        for (int i = 0; i < 3; i++)
        {
            if (temp[i] < 5)
            {
                itemType[i] = 0;
            }
            else if (temp[i] < 7 && temp[i] > 4)
            {
                itemType[i] = 1;
            }
            else if (temp[i] < (int)SALE_ITEMS.NUM_MAX || temp[i] > 6)
            {
                itemType[i] = 2;
            }
        }


    }
}
