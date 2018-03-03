using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    // Game Objects to spawn the ground
    [Header("Ground to spawn")]
    public List<GameObject> spawnGround;

    [HideInInspector]
    public List<GameObject> spawnClone;

    //Game Objects for the enemies to spawn
    [Header("Civilians to spawn")]
    public GameObject[] civilianSpawn;

    [HideInInspector]
    public List<GameObject> civilianSpawnClone;

    [Header("Guards to spawn")]
    public GameObject[] guardSpawn;

    [HideInInspector]
    public List<GameObject> guardSpawnClone;

    [Header("Buildings to spawn")]
    public List<GameObject> buildingSpawn;

    [HideInInspector]
    public List<GameObject> buildingSpawnClone;

    //Player Transform
    public GameObject player;

    //Spawner Area
    public GameObject spawner;

    //Last Z size of the ground spawn
    float lastZGSize = 0;
    float lastZBSize = 0;

    //Last Z location of the ground spawn
    float zGLocation = 0;
    float zBLocation = 0;

    //Enemy spawn location
    Vector3 enemySpawnLocation = new Vector3(0, 0, 0);

    //Start spawn distance
    [Range(40, 400)]
    float spawnDistance = 150;

    Vector3 groundSpawnLocation = new Vector3(0, 0, 0);
    Vector3 buildingSpawnLocation = new Vector3(0, 0, 0);
    int x, y, z, toSpawn, amountSpawn = 0;


    // Use this for initialization
    void Start () {


        // Spawn initial ground
        foreach (GameObject item in spawnGround)
        {
            groundSpawnLocation = new Vector3(0, 0, lastZGSize + zGLocation);
            spawnClone.Add(Instantiate(item, groundSpawnLocation, Quaternion.Euler(0, 0, 0)));
            lastZGSize = item.GetComponent<BoxCollider>().size.z;
            zGLocation = groundSpawnLocation.z;
            
            x++;
        }

        // Spawn initial buildings
        foreach (GameObject p in buildingSpawn)
        {
            buildingSpawnLocation = new Vector3(spawnClone[0].GetComponent<Renderer>().bounds.size.x, 0, lastZBSize + zBLocation);
            buildingSpawnClone.Add(Instantiate(buildingSpawn[y], buildingSpawnLocation, Quaternion.Euler(0, 0, 0)));
            lastZBSize = buildingSpawnClone[y].GetComponent<Renderer>().bounds.size.z;
            zBLocation = buildingSpawnClone[y].GetComponent<Transform>().position.z;
            y++;
        }

        InvokeRepeating("spawnGroundFunc", 1, 1f);
        InvokeRepeating("spawnBuildingFunc", 1, 0.5f);
        InvokeRepeating("spawnPeopleFunc", 1, 1);
    }
	
	// Update is called once per frame
	void Update () {

    }


    void spawnGroundFunc()
    {
        Debug.Log("GroundSpawnLocationZ: " + groundSpawnLocation.z + " PlayerTransformZ: " + player.transform.position.z);
        
        if (groundSpawnLocation.z - player.transform.position.z <= spawnDistance && spawnGround.Count != 0)
        {
            int randSpawnGround = Random.Range(0, spawnGround.Count-1);
            groundSpawnLocation = new Vector3(0, 0, lastZGSize + zGLocation);
            spawnClone.Add(Instantiate(spawnGround[randSpawnGround], groundSpawnLocation, Quaternion.Euler(0, 0, 0)));
            lastZGSize = spawnGround[randSpawnGround].GetComponent<BoxCollider>().size.z;
            zGLocation = groundSpawnLocation.z; ;
            Debug.Log("lastZGSize: " + spawnGround[randSpawnGround] + " zGLocation: " + spawnClone.ToArray()[x].GetComponent<BoxCollider>().size.z);
            x++;
        }
    }

    void spawnBuildingFunc()
    {
        if (buildingSpawnLocation.z - player.transform.position.z <= spawnDistance && buildingSpawn.Count != 0)
        {
            int randSpawnBuilding = Random.Range(0, buildingSpawn.Count);
            buildingSpawnLocation = new Vector3(spawnGround[0].GetComponent<Renderer>().bounds.size.x, 0, lastZBSize + zBLocation);
            buildingSpawnClone.Add(Instantiate(buildingSpawn[randSpawnBuilding], buildingSpawnLocation, Quaternion.Euler(0, 90, 0)));
            lastZBSize = buildingSpawnClone[y].GetComponent<Renderer>().bounds.size.z;
            zBLocation = buildingSpawnClone[y].GetComponent<Transform>().position.z;

            y++;
        }
    }

    void spawnPeopleFunc()
    {
        amountSpawn = Random.Range(0, 4);
        while (amountSpawn > 0 && civilianSpawn.Length != 0)
        {

            enemySpawnLocation = new Vector3(Random.Range(-spawner.GetComponent<BoxCollider>().size.x / 2, spawner.GetComponent<BoxCollider>().size.x  /2), 1f, Random.Range(spawner.transform.position.z, spawner.transform.position.z + spawner.GetComponent<BoxCollider>().size.z));
            toSpawn = Random.Range(0, 100);
            //Spawn civilian
            if (toSpawn <= 75)
            {
                if (Random.Range(0, 4) <= 3)
                {
                    civilianSpawnClone.Add(Instantiate(civilianSpawn[Random.Range(0, civilianSpawn.Length - 1)], enemySpawnLocation, Quaternion.Euler(0, 0, 0)));
                }
                else
                {
                    civilianSpawnClone.Add(Instantiate(civilianSpawn[Random.Range(0, civilianSpawn.Length - 1)], enemySpawnLocation, Quaternion.Euler(0, 0, 0)));
                }              
            }
            //Spawn Guard
            else if(toSpawn > 75 && toSpawn <= 100)
            {
                guardSpawnClone.Add(Instantiate(guardSpawn[Random.Range(0, guardSpawn.Length - 1)], enemySpawnLocation, Quaternion.Euler(0, 0, 0)));
            }
            z++;
            amountSpawn--;
        }
    }
}
