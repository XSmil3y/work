using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour {

    LevelManager LM;
    bool CanExit;
    GameObject Boundaries;
    private void Awake()
    {
        LM = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        Boundaries = GameObject.Find("Boundaries");
    }

    // Update is called once per frame
    void Update () {
        CanExit = LM.GetCanExit();

        if (CanExit)
        {
            Boundaries.SetActive(false);
        }
	}
}
