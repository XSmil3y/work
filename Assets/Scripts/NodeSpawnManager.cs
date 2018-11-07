using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawnManager : MonoBehaviour {

    GameObject[] NodeSpawnPoints;
    List<GameObject> ActiveNodeSpawnPoints = new List<GameObject>();
    public int NodeSpawnPointNum;
    public GameObject Node;

    // Use this for initialization
    void Awake () {
        NodeSpawnPoints = GameObject.FindGameObjectsWithTag("NodeSpawnPoint");

        if (NodeSpawnPoints != null)
        {
            for (int i = 0; i < NodeSpawnPoints.Length; i++)
            {
                ActiveNodeSpawnPoints.Add(NodeSpawnPoints[i]);
            }

            for (int i = 0; i < NodeSpawnPointNum; i++)
            {
                int x = (int)Random.Range(0, ActiveNodeSpawnPoints.Count);

               GameObject NewNode = Instantiate(Node, ActiveNodeSpawnPoints[x].transform.position, ActiveNodeSpawnPoints[x].transform.rotation);
                NewNode.transform.SetParent(null);
                ActiveNodeSpawnPoints.RemoveAt(x);
            }
        }


	}


    // Update is called once per frame



}
