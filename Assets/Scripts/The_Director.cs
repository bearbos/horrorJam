using UnityEngine;
using System.Collections;

public class The_Director : MonoBehaviour {

    // Data Members
    int wantedLevel = 1;
    int streetLvl = 2;
    int candy = 0;
    float healthRatio = 1.0f;

    public GameObject LevelChunk;

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
 
    


    // Use this for initialization
    void Start ()
    {
        SpawnHouses();
        SpawnDecorations();
        SpawnRoofs();
        SpawnEnemies();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
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
           
            Debug.Log("Instantiating House " + houseIndex.ToString());
        }

        // Destroy all the house tags
        for (int i = 4; i > 0; i--)
        {
            Destroy(houseNodes[numHouses - 1]);
            numHouses -= 1;
            Debug.Log(numHouses.ToString() + " houses remaining");
        }

        if (numHouses == 0)
            Debug.Log("All houses deleted");
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
        }

        // Destroy all the house tags
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
        for (int i = 0; i < natureSize; i++)
        {
            GameObject tempNats;
            int natureIndex = Random.Range(0, theNatural.Length);
            bool isAvailable = theDecorations[natureIndex].activeInHierarchy;

            int spawnIndex = Random.Range(0, decorationSize);

            tempNats = Instantiate(theNatural[natureIndex], decorationNodes[spawnIndex].gameObject.transform.position, gameObject.transform.rotation) as GameObject;

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
        }

        // Destroy all the house tags
        for (int i = 50; i > 0; i--)
        {
            Destroy(decorationNodes[decorationSize - 1]);
            decorationSize -= 1;
            Debug.Log(decorationSize.ToString() + " houses remaining");
        }

        if (decorationSize == 0)
            Debug.Log("All houses deleted");

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

        for(int i = candy; i > 0; i -= 50)
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
                numPolice = 0;
                break;
            case 1:
                numPolice = 1;
                break;
            case 2:
                numPolice = 2;
                break;
            case 3:
                numPolice = 4;
                break;
            case 4:
                numPolice = 8;
                break;
            case 5:
                numPolice = 16;
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
}
