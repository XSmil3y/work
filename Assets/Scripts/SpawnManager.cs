using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject[] EnemyTypes;
    GameObject[] SpawnPoints;
    List<GameObject> ActiveSpawnPoints = new List<GameObject>();
    
    int ActiveEnemies;
    public int MinimumEnemies;
    int enemySpawnNum;
    int SpawnPointNum;
    float SpawnTimer = 0;

    // Use this for initialization
    void Awake () {
        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        if (SpawnPoints != null)
        {
            for(int i = 0; i < SpawnPoints.Length; i++)
            {
                ActiveSpawnPoints.Add(SpawnPoints[i]);
            }
        }
        for(int i = ActiveEnemies; i <= MinimumEnemies -1; i++)
        {
            enemySpawnNum = (int)Random.Range(0, EnemyTypes.Length);
            SpawnPointNum = (int)Random.Range(0, SpawnPoints.Length);

           SpawnEnemy(EnemyTypes[enemySpawnNum], SpawnPointNum);

        }
    }
	
	// Update is called once per frame
	void Update () {
        if (ActiveEnemies < MinimumEnemies + 1)
        {
           /* if (SpawnTimer > 0)
            {
                SpawnTimer -= Time.deltaTime;
            }*/
           // else
            //{
                enemySpawnNum = (int)Random.Range(0, EnemyTypes.Length);
                SpawnPointNum = (int)Random.Range(0, ActiveSpawnPoints.Count);

                SpawnEnemy(EnemyTypes[enemySpawnNum], SpawnPointNum);
                SpawnTimer = 1;
           // }
        }

        else { SpawnTimer = 1; }
	}

    public void  ReduceActiveEnemies()
    {
        ActiveEnemies -= 1;
    }

     

    //Make a SpawnEnemy Function, After which you should 
    //make a function in the Ai Control Script that counts down the ActiveEnemy Count
    //after which you should test that the AI are in fact spawning, then make the Coroutine 
    //that removes the spawnpoints for a limited amount of time, and then re Adds them
    //Then Finally, Make A spawn Timer/Delay

    public void SpawnEnemy(GameObject Enemy, int Position)
    {
        GameObject _Enemy= Instantiate(Enemy, SpawnPoints[Position].transform.position, Quaternion.identity);
       _Enemy.transform.SetParent(null);
        ActiveEnemies += 1;
    }
    /*
    IEnumerator RemoveSpawnPoint(int Element)
    {
        GameObject tempRemovedSpawn;
        tempRemovedSpawn = ActiveSpawnPoints[Element];
        ActiveSpawnPoints.RemoveAt(Element);
        yield return new WaitForSeconds(5);
        ActiveSpawnPoints.Add(tempRemovedSpawn);
    }
    */
}
