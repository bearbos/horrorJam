using UnityEngine;
using System.Collections;

public class The_Director : MonoBehaviour {

    // Data Members
    int wantedLevel = 1;
    int streetLvl = 1;
    int candy = 0;
    float healthRatio = 1.0f;

    public GameObject LevelChunk;

    GameObject oldChunk;
    GameObject currChunk;
    GameObject newChunk;

    // Things to spawn
    [SerializeField]
    GameObject[] theHouses;

    [SerializeField]
    GameObject[] theNatural;

    [SerializeField]
    GameObject[] theDecorations;

    [SerializeField]
    GameObject[] theEnemies;

    [SerializeField]
    GameObject[] theRoofs;

    // Use this for initialization
    void Start ()
    {
        SpawnHouses();
        SpawnDecorations();
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

    public void SpawnNewChunk()
    {
        GameObject newNode = GameObject.FindWithTag("NewNodeSpawn");
        GameObject justSpawned = Instantiate(LevelChunk, newNode.gameObject.transform.position, gameObject.transform.rotation) as GameObject;
       
        Destroy(newNode);
        SpawnHouses();
        SpawnDecorations();

       

        if(currChunk)
            Destroy(currChunk);

        if(newChunk)
            currChunk = newChunk;

        newChunk = justSpawned;
    }
}
