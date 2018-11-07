using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHighScoreScene : MonoBehaviour {

	public void loadHighScoreScene()
    {
        SceneManager.LoadScene("HighScores", LoadSceneMode.Single);
    }
}
