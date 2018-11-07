using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Boardable : MonoBehaviour
{

    private GameStateManager GSM;
   

    private bool Paused = false;
    private int Element;
    public int ScoreValue;

    private Score score;

    private void Start()
    {
        GSM = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        score = Camera.main.GetComponentInChildren<Score>();
    }

    private void Update()
    {
        GSM.GetPaused();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {



            if (Paused) { return; }
            else
            {
                if (this.gameObject.tag == "Sentry")
                {
                    GenerateLevel("Sentry");

                }
                else if (this.gameObject.tag == "Scout")
                {
                    GenerateLevel("Scout");
                }
                else if (this.gameObject.tag == "Mother")
                {
                    GenerateLevel("Mother");
                }
                else
                {
                    return;
                }
                GSM.SetPaused(true);
                SceneManager.LoadScene("FPS Scene", LoadSceneMode.Additive);
                GSM.SetActiveScene("Fps Scene");
                DestroyShip();

            }

        }


    }

    private void SetBoundary()
    {

    }

    private void GenerateLevel(string Ship)
    {
        
        if (Ship == "Sentry")
        {
             Element = Random.Range(0, GSM.SentryShips.Length-1);
            GSM.SetArray(GSM.SentryShips);
        }

        if (Ship == "Scout")
        {
             Element = Random.Range(0, GSM.ScoutShips.Length-1);
            GSM.SetArray(GSM.ScoutShips);
        }

        if (Ship == "Mother")
        {

             Element = Random.Range(0, GSM.MotherShips.Length-1);
            //Debug.Log(GSM.MotherShips.Length);
          

            GSM.SetArray(GSM.MotherShips);
        }

        GSM.SetElement(Element);
       // Debug.Log(Element);

    }

    void DestroyShip()
    {
        score.IncreaseScore(ScoreValue);
        Destroy(this.gameObject);
    }

}
