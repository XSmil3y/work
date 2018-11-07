using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour {
    private GameStateManager GSM;
    private LevelManager LM;
    private bool Paused;

    private void Awake()
    {
        GSM = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        LM = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        GSM.SetPaused(false);
        //LM.UnloadLevel();
     SceneManager.UnloadSceneAsync("FPS Scene");
    }
}
