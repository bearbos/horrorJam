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
    GameObject[] theDecorations;

    [SerializeField]
    GameObject[] theEnemies;

    [SerializeField]
    GameObject[] theRoofs;

    // Use this for initialization
    void Start ()
    {
        SpawnHouses();
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
            int houseIndex = Random.Range(0, theHouses.Length);
            GameObject tempHouse = Instantiate(theHouses[houseIndex], houseNodes[i].gameObject.transform.position, gameObject.transform.rotation) as GameObject;
           
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

    public void SpawnNewChunk()
    {
        GameObject newNode = GameObject.FindWithTag("NewNodeSpawn");
        GameObject justSpawned = Instantiate(LevelChunk, newNode.gameObject.transform.position, gameObject.transform.rotation) as GameObject;
       
        Destroy(newNode);
        SpawnHouses();

       

        if(currChunk)
            Destroy(currChunk);

        if(newChunk)
            currChunk = newChunk;

        newChunk = justSpawned;
    }
}
