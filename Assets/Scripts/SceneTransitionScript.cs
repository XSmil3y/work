using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionScript : MonoBehaviour {
    Animator Cam;
	public void LoadFPSScene()
    {
        SceneManager.LoadScene("FPS Scene", LoadSceneMode.Additive);
        Cam = Camera.main.GetComponent<Animator>();
        Cam.SetBool("Transition", false);

    }

    public void LoadDogfightScene()
    {

    }
}
