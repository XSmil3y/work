using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Score : MonoBehaviour {

    public int ScoreNum = 0000;
    Text[] scores;

	void Awake()
    {
        scores = this.GetComponentsInChildren<Text>();

        UpdateScore();

    }
   
    
     /*
    void Update()
    {
        UpdateScore();
    }
   */

    void UpdateScore()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            if (ScoreNum < 10) {
                scores[i].text = "00000" + ScoreNum.ToString();
            }
            else if (ScoreNum < 100)
            {
                scores[i].text = "0000" + ScoreNum.ToString();
            }
            else if (ScoreNum < 1000)
            {
                scores[i].text = "000" + ScoreNum.ToString();
            }
            else if (ScoreNum < 10000)
            {
                scores[i].text = "00" + ScoreNum.ToString();
                
            }
            else if (ScoreNum < 100000)
            {
                scores[i].text = "0" + ScoreNum.ToString();
               
            }
            else if (ScoreNum < 1000000)
            {
                scores[i].text = ScoreNum.ToString();
               
            }

        }
    }

    public void IncreaseScore(int score)
    {
        ScoreNum += score;
        UpdateScore();
    }
}
