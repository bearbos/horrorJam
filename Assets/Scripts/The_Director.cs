using UnityEngine;
using System.Collections;

public class The_Director : MonoBehaviour {

    // Data Members
    public int prevEnemies = 0;
    public int numEnemies;

    public GameObject LevelChunk;

    // HUD
    public GameObject theTimer;
    public GameObject theCandy;
    public GameObject theScore;
    public GameObject theStreet;
    public GameObject theWantedLvl;
    public GameObject theHealth;
    public GameObject theHealthBar;
    public GameObject healthBarAnchor;

    int GameTimer = 91;
    int CandyCount = 0;
    int PlayerScore = 0;
    int wantedLevel = 0;
    public int streetLvl = 1;
    string streetName;
    string wantedName;
    int percentHealth;

    public GameObject fadeToBlack;
    bool fadeToBlackBool = false;
    float transitionTimer = 0.0f;

    public GameObject nextLevelText;
    public string nextLevelString = "First Street";

    // Things to spawn
    [SerializeField]
    GameObject[] theHouses;

    [SerializeField]
    GameObject[] theNatural;

    [SerializeField]
    GameObject[] theDecorations;

    [SerializeField]
    GameObject[] theKids;

    [SerializeField]
    GameObject[] theParents;

    [SerializeField]
    GameObject[] thePolice;

    [SerializeField]
    GameObject[] theRoofs;

    public float privateTimer = 0.0f;

    [SerializeField]
    string[] streetName1;

    [SerializeField]
    string[] streetName2;


    // Use this for initialization
    void Awake()
    {
        SpawnHouses();
        SpawnDecorations();
        SpawnRoofs();
        SpawnEnemies();

        Color empty = new Color(0, 0, 0, 0);
        fadeToBlack.gameObject.GetComponent<SpriteRenderer>().color = empty;
        nextLevelText.gameObject.GetComponent<TextMesh>().text = " ";
    }

    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (fadeToBlackBool == true)
            transitionTimer += Time.deltaTime;

        if(transitionTimer >= 1.5f)
        {
            nextLevelText.gameObject.GetComponent<TextMesh>().text = " ";
            Color empty = new Color(0, 0, 0, 0);
            fadeToBlack.gameObject.GetComponent<SpriteRenderer>().color = empty;
            fadeToBlackBool = false;
            transitionTimer = 0.0f;
        }

        privateTimer += Time.deltaTime;

	    if(privateTimer >= 0.5f)
        {
            ManageEnemies();
            privateTimer = 0.0f;
        }

        // Update the time
        GameTimer = 60;
        GameTimer += (int)GameObject.FindWithTag("Player").gameObject.GetComponent<playerStats>().timer;
        theTimer.gameObject.GetComponent<TextMesh>().text = GameTimer.ToString();

        if (GameTimer < 0)
        {
            LoadNewStreet();
            GameObject.FindWithTag("Player").gameObject.GetComponent<playerStats>().timer = 5.0f;
        }

        // Update the Candy
        CandyCount = (int)GameObject.FindWithTag("Player").gameObject.GetComponent<playerStats>().candy;
        theCandy.gameObject.GetComponent<TextMesh>().text = CandyCount.ToString();

        // Update score
        PlayerScore = (int)GameObject.FindWithTag("Player").gameObject.GetComponent<playerStats>().score;
        theScore.gameObject.GetComponent<TextMesh>().text = PlayerScore.ToString();

        // Wanted Level
        wantedLevel = (int)GameObject.FindWithTag("Player").gameObject.GetComponent<playerStats>().notoriety;

        switch(wantedLevel)
        {
            case 0:
                wantedName = "Not Spooky";
                break;
            case 1:
                wantedName = "Kinda Spooky";
                break;
            case 2:
                wantedName = "2spooky";
                break;
            case 3:
                wantedName = "Very Spooky";
                    break;
            case 4:
                wantedName = "#Spooky";
                break;
            case 5:
                wantedName = "SPOOKED";
                break;

        }

        theWantedLvl.gameObject.GetComponent<TextMesh>().text = wantedName;

        // Health %
        float maxHealth = (int)GameObject.FindWithTag("Player").gameObject.GetComponent<playerStats>().maxHealth;
        float currHealth = (int)GameObject.FindWithTag("Player").gameObject.GetComponent<playerStats>().currHealth;

        percentHealth = (int)(currHealth);
        theHealth.gameObject.GetComponent<TextMesh>().text = percentHealth.ToString();

        float currAdren = (int)GameObject.FindWithTag("Player").gameObject.GetComponent<playerStats>().adrenaline;
        float maxAdren = 100.0f;

        theHealthBar.transform.position = healthBarAnchor.transform.position;

        Vector3 theHealthBarScale;
        Vector3 theHealthBarLocation;

        theHealthBarScale = theHealthBar.transform.localScale;
        theHealthBarLocation = theHealthBar.transform.position;

        theHealthBarScale.x = ((currAdren / maxAdren));
        theHealthBarLocation.x -= (1.90f - ((currAdren / maxAdren) * 1.90f));

        theHealthBar.transform.localScale = theHealthBarScale;
        theHealthBar.transform.position = theHealthBarLocation;

    }

    void SpawnHouses()
    {
        GameObject[] houseNodes = GameObject.FindGameObjectsWithTag("HouseSpawner");

        int houseSize = houseNodes.Length;
        int numHouses = 4;

        for(int i = 0; i < numHouses; i++)
        {
            Vector3 newPos = houseNodes[i].gameObject.transform.position;
            newPos.z = 10;
            int houseIndex = Random.Range(0, theHouses.Length);
            GameObject tempHouse = Instantiate(theHouses[houseIndex], newPos, gameObject.transform.rotation) as GameObject;

            int flip = Random.Range(0, 2);
            if(flip == 1)
            {
                Vector3 flipPos = tempHouse.gameObject.transform.localScale;
                flipPos.x *= -1;
                tempHouse.transform.localScale = flipPos;
            }
           
        }

        // Destroy all the house tags
        for (int i = 4; i > 0; i--)
        {
            Destroy(houseNodes[numHouses - 1]);
            numHouses -= 1;
           
        }
  
    }

    void SpawnRoofs()
    {
        GameObject[] roofNodes = GameObject.FindGameObjectsWithTag("RoofSpawner");

        int roofSize = roofNodes.Length;
        int numRoofs = 4;

        for (int i = 0; i < numRoofs; i++)
        {
            Vector3 newPos = roofNodes[i].gameObject.transform.position;
            newPos.z = 10;
            int roofIndex = Random.Range(0, theRoofs.Length);
            GameObject tempRoof = Instantiate(theRoofs[roofIndex], newPos, gameObject.transform.rotation) as GameObject;

            int flip = Random.Range(0, 2);
            if (flip == 1)
            {
                Vector3 flipPos = tempRoof.gameObject.transform.localScale;
                flipPos.x *= -1;
                tempRoof.transform.localScale = flipPos;
            }
        }



        // Destroy all the roof tags
        for (int i = 4; i > 0; i--)
        {
            Destroy(roofNodes[numRoofs - 1]);
            numRoofs -= 1;
        }
    }

    void SpawnDecorations()
    {
        GameObject[] decorationNodes = GameObject.FindGameObjectsWithTag("miscSpawner");

        int natureSize = Random.Range(0, theNatural.Length);

        int decorationSize = decorationNodes.Length;
        int numDecorations = Random.Range((int)(6 + streetLvl), (int)(10 + streetLvl));

        // Spawn trees and shit
        for (int i = 0; i < 10; i++)
        {
            GameObject tempNats;
            int natureIndex = Random.Range(0, theNatural.Length);
            bool isAvailable = theDecorations[natureIndex].activeInHierarchy;

            int spawnIndex = Random.Range(0, decorationSize);

            tempNats = Instantiate(theNatural[natureIndex], decorationNodes[spawnIndex].gameObject.transform.position, gameObject.transform.rotation) as GameObject;

            int flip = Random.Range(0, 2);
            if (flip == 1)
            {
                Vector3 flipPos = tempNats.gameObject.transform.localScale;
                flipPos.x *= -1;
                tempNats.transform.localScale = flipPos;
            }

            isAvailable = true;
        }

        // Spawn decoration and shit
        for (int i = 0; i < numDecorations; i++)
        {
            GameObject tempDecor;
            int decorIndex = Random.Range(0, theDecorations.Length);
            bool isAvailable = theDecorations[decorIndex].activeInHierarchy;

            int spawnIndex = Random.Range(0, decorationSize);

            tempDecor = Instantiate(theDecorations[decorIndex], decorationNodes[spawnIndex].gameObject.transform.position, gameObject.transform.rotation) as GameObject;

            int flip = Random.Range(0, 2);
            if (flip == 1)
            {
                Vector3 flipPos = tempDecor.gameObject.transform.localScale;
                flipPos.x *= -1;
                tempDecor.transform.localScale = flipPos;
            }
        }

        // Destroy all the house tags
        for (int i = 50; i > 0; i--)
        {
            Destroy(decorationNodes[decorationSize - 1]);
            decorationSize -= 1;
           
        }
        

    }

    void SpawnEnemies()
    {
        GameObject[] enemyNodes = GameObject.FindGameObjectsWithTag("EnemySpawner");

        int enemySize = enemyNodes.Length;

        // Street Number
        // Amt Candy
        // Wanted Level

        int numChildren = 10;
        int candyLevel = 15;

        for(int i = CandyCount; i > 0; i -= 50)
        {
            candyLevel -= 1;
        }

        // Calculate Kids
        numChildren = (int)((numChildren - wantedLevel) * ((float)streetLvl / 10.0f) + (int)(candyLevel / 2));

        // Spawn Children
        for (int i = 0; i < numChildren; i++)
        {
            int randIndex = Random.Range(0, enemyNodes.Length);
            Vector3 newPos = enemyNodes[randIndex].gameObject.transform.position;
            int kidIndex = Random.Range(0, theKids.Length);
            GameObject tempKids = Instantiate(theKids[kidIndex], newPos, gameObject.transform.rotation) as GameObject;
        }

        int numParents = (streetLvl - wantedLevel);
        if (numParents < 0)
            numParents = 0;

        // Spawn Parents
        for (int i = 0; i < numParents; i++)
        {
            int randIndex = Random.Range(0, enemyNodes.Length);
            Vector3 newPos = enemyNodes[randIndex].gameObject.transform.position;
            int parentIndex = Random.Range(0, theParents.Length);
            GameObject tempParents = Instantiate(theParents[parentIndex], newPos, gameObject.transform.rotation) as GameObject;
        }

        int numPolice = 0;
        // Spawn police
        switch(wantedLevel)
        {
            case 0:
                numPolice = 1;
                break;
            case 1:
                numPolice = 2;
                break;
            case 2:
                numPolice = 4;
                break;
            case 3:
                numPolice = 8;
                break;
            case 4:
                numPolice = 16;
                break;
            case 5:
                numPolice = 32;
                break;
                // Fuck
        }

        // Spawn Parents
        for (int i = 0; i < numPolice; i++)
        {
            int randIndex = Random.Range(0, enemyNodes.Length);
            Vector3 newPos = enemyNodes[randIndex].gameObject.transform.position;
            int policeIndex = Random.Range(0, thePolice.Length);
            Instantiate(thePolice[policeIndex], newPos, gameObject.transform.rotation);
        }

        int deleteEnemies = enemySize;
        // Destroy all the house tags
        for (int i = enemySize; i > 0; i--)
        {
            Destroy(enemyNodes[deleteEnemies - 1]);
            deleteEnemies -= 1;
            
        }
    }

    public void SpawnNewChunk()
    {
        GameObject newNode = GameObject.FindWithTag("NewNodeSpawn");
        GameObject justSpawned = Instantiate(LevelChunk, newNode.gameObject.transform.position, gameObject.transform.rotation) as GameObject;
       
        Destroy(newNode);

        SpawnHouses();
        SpawnDecorations();
        SpawnRoofs();
        SpawnEnemies();
    }

    void ManageEnemies()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        numEnemies = allEnemies.Length;

        if(numEnemies < prevEnemies)
        {
            for (int i = 0; i < numEnemies; i++)
            {
                if (allEnemies[i].gameObject.GetComponent<e_StateMachine>() != null)
                {
                    if (allEnemies[i].gameObject.GetComponent<e_StateMachine>().eGuard == true)
                    {
                        allEnemies[i].gameObject.GetComponent<e_StateMachine>().eAggro = true;
                        allEnemies[i].gameObject.GetComponent<e_StateMachine>().eGuard = false;
                    }
                }
            }
        }

        prevEnemies = numEnemies;
    }

    void LoadNewStreet()
    {
        /*
        SpawnNewChunk();
        Vector3 newCamPos;
        Vector3 newPlayerPos;

        GameObject theCamera = GameObject.FindWithTag("MainCamera");
        GameObject thePlayer = GameObject.FindWithTag("Player");

        newCamPos = theCamera.transform.position;

        newCamPos.x += 54;
        theCamera.transform.position = newCamPos;

        newPlayerPos = GameObject.FindWithTag("PlayerSpawn").transform.position;
        thePlayer.transform.position = newCamPos;
        */

        GenerateStreetName();

        streetLvl += 1;
        Color empty = new Color(1, 1, 1, 1);
        fadeToBlack.gameObject.GetComponent<SpriteRenderer>().color = empty;
        nextLevelText.gameObject.GetComponent<TextMesh>().text = "Street " + streetLvl.ToString();
        fadeToBlackBool = true;
    }

    void GenerateStreetName()
    {
        int randName1 = Random.Range(0, streetName1.Length);
        int randName2 = Random.Range(0, streetName2.Length);

        string temp = " ";
        string temp2 = streetName1[randName1].ToString();
        string temp3 = " ";
        string temp4 = streetName2[randName2].ToString();

        temp = temp2 + temp3 + temp4;
        theStreet.GetComponent<TextMesh>().text = temp;
    }
}
