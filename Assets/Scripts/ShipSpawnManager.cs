using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawnManager : MonoBehaviour {

    public GameObject[] EnemyTypes;
    GameObject[] ShipSpawnPoints;
    List<GameObject> ActiveSpawnPoints = new List<GameObject>();

    int ActiveShips;
    public int MinimumShips;
    int enemySpawnNum;
    int SpawnPointNum;
    float SpawnTimer = 0;

    // Use this for initialization
    void Awake()
    {
        ShipSpawnPoints = GameObject.FindGameObjectsWithTag("ShipSpawnPoint");

        if (ShipSpawnPoints != null)
        {
            for (int i = 0; i < ShipSpawnPoints.Length; i++)
            {
                ActiveSpawnPoints.Add(ShipSpawnPoints[i]);
            }
        }
        for (int i = ActiveShips; i <= MinimumShips; i++)
        {
            enemySpawnNum = (int)Random.Range(0, EnemyTypes.Length);
            SpawnPointNum = (int)Random.Range(0, ActiveSpawnPoints.Count);

            SpawnEnemy(EnemyTypes[enemySpawnNum], SpawnPointNum);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveShips <= MinimumShips)
        {
            if (SpawnTimer > 0)
            {
                SpawnTimer -= Time.deltaTime;
            }
            else
            {
                enemySpawnNum = (int)Random.Range(0, EnemyTypes.Length);
                SpawnPointNum = (int)Random.Range(0, ActiveSpawnPoints.Count);

                SpawnEnemy(EnemyTypes[enemySpawnNum], SpawnPointNum);
                SpawnTimer = 3;
            }
        }

        else { SpawnTimer = 10; }
    }

    public void ReduceActiveEnemies()
    {
        ActiveShips -= 1;
    }



    //Make a SpawnEnemy Function, After which you should 
    //make a function in the Ai Control Script that counts down the ActiveEnemy Count
    //after which you should test that the AI are in fact spawning, then make the Coroutine 
    //that removes the spawnpoints for a limited amount of time, and then re Adds them
    //Then Finally, Make A spawn Timer/Delay

    public void SpawnEnemy(GameObject Enemy, int Position)
    {
        GameObject _Enemy = Instantiate(Enemy, ActiveSpawnPoints[Position].transform.position, Quaternion.identity);
        _Enemy.transform.SetParent(ActiveSpawnPoints[Position].transform);
        ActiveShips += 1;
    }

   
}
