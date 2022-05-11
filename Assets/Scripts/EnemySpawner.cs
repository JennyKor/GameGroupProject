using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] private float timeToFirstWave;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float numberOfSpawns; //per wave

    private static int numberOfWaves;

    private bool usingThirdSpawn = false;
    private bool usingFourthSpawn = false;

    private int area;

    Vector3 spawnPoint;
    Vector3 spawnArea1;
    Vector3 spawnArea2;
    Vector3 spawnArea3;
    Vector3 spawnArea4;
    

    // Start is called before the first frame update
    void Start()
    {
        numberOfWaves = 0;

        // Retrieving spawn areas' positions
        spawnArea1 = GameObject.FindGameObjectWithTag("SpawnArea1").transform.position;
        spawnArea2 = GameObject.FindGameObjectWithTag("SpawnArea2").transform.position;
        spawnArea3 = GameObject.FindGameObjectWithTag("SpawnArea3").transform.position;
        spawnArea4 = GameObject.FindGameObjectWithTag("SpawnArea4").transform.position;

        // The first wave spawns from the SpawnArea1
        spawnPoint = spawnArea1;
        InvokeRepeating("SpawnEnemies", timeToFirstWave, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {    
        // Controlling the number of enemy spawns and the time between 
        //the waves. Easy to adjust and add more cases here once we get to play testing.
        switch (numberOfWaves)
        {
            case 5: 
                numberOfSpawns = 3;
                break;
            case 10: 
                CancelInvoke();
                numberOfSpawns = 5;
                spawnInterval = 15;
                InvokeEnemyWaves();
                break;
            case 20:
                CancelInvoke();
                usingThirdSpawn = true;
                numberOfSpawns = 8;
                spawnInterval = 20;
                InvokeEnemyWaves();
                break;
            case 30: 
                CancelInvoke();
                usingFourthSpawn = true;
                numberOfSpawns = 10;
                spawnInterval = 30;
                InvokeEnemyWaves();
                break;
        }
    }

    void InvokeEnemyWaves()
    {  
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {
            spawnAreaBounds();
            //enemy.transform.position = spawnPoint;
            // prevents enemies from rotating on their axis:
            //enemy.transform.rotation = Quaternion.identity;
            Instantiate(enemy, spawnPoint, Quaternion.identity);     
        }
        numberOfWaves++;
        Debug.Log(numberOfWaves + ", number of enemies: " + numberOfSpawns);
        randomizeSpawnArea();
    }

    // Randomize the spawn area for enemy waves
    void randomizeSpawnArea()
    {
        
        if (!usingThirdSpawn)
        {
            area = Random.Range(1, 3);
        }
        if (usingThirdSpawn)
        {
            area = Random.Range(1, 4);
        }
        if (usingFourthSpawn)
        {
            area = Random.Range(1, 5);
        }
        //Debug.Log(area);
        switch (area)
        {
            case 1:
                spawnPoint = spawnArea1;
                break;
            case 2:
                spawnPoint = spawnArea2;
                break;
            case 3:
                spawnPoint = spawnArea3;
                break;
            case 4:
                spawnPoint = spawnArea4;
                break;
        }
    }

    // Boundaries for spawning area
    void spawnAreaBounds()
    {
        spawnPoint.x = Random.Range(spawnPoint.x - 1f, spawnPoint.x + 1f);
        spawnPoint.y = Random.Range(spawnPoint.y - 1f, spawnPoint.y + 1f);
    }
}
