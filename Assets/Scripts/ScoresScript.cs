using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoresScript : MonoBehaviour {
    public ScoreList SL;
    private int i;
    public Text txt;
    public Text txt2;
	// Use this for initialization
	void Start () {
		for( i = 0; i < 9; i++)
        {
            txt.text += SL.GetScore(i).ToString() + "\n" ;
            txt2.text += SL.GetScore(i).ToString() + "\n";
        }
	}
	
	
}
