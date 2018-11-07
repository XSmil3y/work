using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {
    BoxCollider ExitCol;
    GameStateManager GSM;
    private void Awake()
    {
        ExitCol = this.GetComponent<BoxCollider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        GSM = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();

       // GSM.Des
    }

}
