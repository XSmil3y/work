using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

    private bool ScenePaused;
    public Camera MainCamera;
    private bool Disabled;
    private int Element;
    private GameObject[] ChosenArray;

    public GameObject[] SentryShips;

    public GameObject[] ScoutShips;

    public GameObject[] MotherShips;

    public GameObject[] LaserShips;

    public AudioClip Dogfight;
    public AudioClip MainMenu;
    public AudioClip FPS;

    private void Awake()
    {
       //AudioSource.
    }



    public void SetPaused(bool Pause)
    {
        ScenePaused = Pause;
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("Projectile").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Projectile")[i]);

        }
        
    }

    public bool GetPaused()
    {
        return ScenePaused;

    }

    private void Update()
    {
        if (ScenePaused && !Disabled)
        {
            MainCamera.GetComponent<AudioListener>().enabled = false; //clean this up later
            Disabled = true;
        }

        if(!ScenePaused && Disabled)
        {
            MainCamera.GetComponent<AudioListener>().enabled = true; //clean this up later
            Disabled = false;

        }
    }
    public string GetActiveScene()
    {
        Scene _scene = SceneManager.GetActiveScene();
            return _scene.name;
    }

    public void SetActiveScene(string scene)
    {
        if (scene != null)
        {
            Scene _scene = SceneManager.GetSceneByName(scene);
            SceneManager.SetActiveScene(_scene);
            Debug.Log("Scene Set to " + scene);
        }
    }

    public void SetElement(int i)
    {
        Element = i;
    }

    public void SetArray(GameObject[] Array)
    {
        ChosenArray = Array;
    }

    public int GetElement()
    {
        return Element;
    }

    public GameObject[] GetArray()
    {
        return ChosenArray;
    }
    
}
