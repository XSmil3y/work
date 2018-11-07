using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;

public class Boardable3D : MonoBehaviour
{
    
    private GameStateManager GSM;
    private BlendSourceVirtualCamera vc;
    private Animator Cam;
    public float ChanceDrop;
    public GameObject SpawnedObject;

    private bool Paused = false;
    private int Element;
    public int ScoreValue;

    private Score score;

    private void Start()
    {
        GSM = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        Cam = Camera.main.GetComponent<Animator>();
        score = Camera.main.GetComponentInChildren<Score>();
        
    }

    private void Update()
    {
        GSM.GetPaused();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
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
                else if(this.gameObject.tag == "LaserShip")
                {
                    GenerateLevel("LaserShip");
                }
            
                else
                {
                    return;
                }
                GSM.SetPaused(true);
                Cam.SetTrigger("Transition");

                //SceneManager.LoadScene("FPS Scene", LoadSceneMode.Additive);
                //GSM.SetActiveScene("Fps Scene");
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
            Element = Random.Range(0, GSM.SentryShips.Length - 1);
            GSM.SetArray(GSM.SentryShips);
        }

        if (Ship == "Scout")
        {
            Element = Random.Range(0, GSM.ScoutShips.Length - 1);
            GSM.SetArray(GSM.ScoutShips);
        }

        if (Ship == "Mother")
        {

            Element = Random.Range(0, GSM.MotherShips.Length - 1);
            //Debug.Log(GSM.MotherShips.Length);


            GSM.SetArray(GSM.MotherShips);
        }

        if (Ship == "LaserShip")
        {

            Element = Random.Range(0, GSM.LaserShips.Length - 1);
            //Debug.Log(GSM.MotherShips.Length);


            GSM.SetArray(GSM.LaserShips);
        }

        GSM.SetElement(Element);
        // Debug.Log(Element);

    }

    void DestroyShip()
    {
        float _Chance = Random.Range(0, 100);

        score.IncreaseScore(ScoreValue);
        if (ChanceDrop > _Chance)
        {
            if (SpawnedObject)
            {
                Instantiate(SpawnedObject, transform.position, Quaternion.identity);
            }
        }

        Destroy(this.gameObject);
    }

}
