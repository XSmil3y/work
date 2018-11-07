using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneScript : MonoBehaviour {

    public Scene NextScene;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        Debug.Log(NextScene.ToString());
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScreen" , LoadSceneMode.Single);
        }
	}
}
