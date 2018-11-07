using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private GameStateManager GSM;
    private Transform LevelSpawn;
    private Vector3 LevelSpawnPoint;
    private GameObject Level;
    private bool Destroyed;
    private bool CanExit;
    private string _scene;
    private NavMeshSurface LevelNavMesh;

    private void Awake()
    {
        LevelSpawn = GameObject.Find("LevelSpawn").transform;
        LevelSpawnPoint = LevelSpawn.position;
        GSM = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        
      
    }
    private void Start()
    {

       
            Generate();
        
    }

    private void CheckActiveScene()
    {
        GSM.GetActiveScene();
    }

    private void Update()
    {
        CheckNodes();
    }

    private void CheckNodes()
    {
     //   Debug.Log(GameObject.FindGameObjectsWithTag("Node").Length);
        if (GameObject.FindGameObjectsWithTag("Node").Length <= 0)
        {
            Destroyed = true;
        }
        if (Destroyed)
        {
            CanExit = true;
        }

    }

    public bool GetCanExit()
    {
        return CanExit;
    }

    private void Generate()
    {
        int element = GSM.GetElement();
        GameObject[] Array = GSM.GetArray();
        //  Debug.Log(element);
        Level = Array[element];
        GameObject InstLevel = Instantiate(Array[element], LevelSpawnPoint, Quaternion.identity);
        LevelNavMesh = Level.GetComponent<NavMeshSurface>();
        InstLevel.transform.SetParent(LevelSpawn);
        //this works, But this is kind of a hack, 
        //There must be a better way to do this
    }




    public void UnloadLevel()
    {
        Destroy(Level);
    }
}
