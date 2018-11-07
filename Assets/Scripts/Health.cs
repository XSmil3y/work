using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Health : MonoBehaviour
    {
    SpawnManager SM;
    ShipSpawnManager SSM;
    Score score;

        public int InitialHealth;
        public int CurrentHealth;
        public int MaxHealth;
        public int ScoreValue;

        public float ChanceDrop;
        public GameObject SpawnedObject;


    private GameStateManager GSM;
        private bool Paused;

        private void Start()
        {

        if (GameObject.Find("SpawnPoints"))
        {
            if (GameObject.Find("SpawnPoints").GetComponent<SpawnManager>())
            {
                SM = GameObject.Find("SpawnPoints").GetComponent<SpawnManager>();
            }
        }

        if (GameObject.Find("ShipSpawnManager"))
        {
            if (GameObject.Find("ShipSpawnManager").GetComponent<ShipSpawnManager>())
            {
                SSM = GameObject.Find("ShipSpawnManager").GetComponent<ShipSpawnManager>();

            }
        }
        CurrentHealth = InitialHealth;
            score = Camera.main.GetComponentInChildren<Score>();

        }

        private void Update()
        {
            // Paused = GSM.GetPaused();
        }

        public void Heal(int HP)
        {
            CurrentHealth += HP;

            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }

        public void Damage(int Dam)
        {
       
        CurrentHealth -= Dam;

            {
                if (CurrentHealth <= 0)
                {
                   // Debug.Log(CurrentHealth);
                    //kill player, Show GameOver
                }

                if (CurrentHealth <= 0)
                {
               // SM.ReduceActiveEnemies();
                Kill();
                }
            }
        }

        public void Kill()
        {
        float _Chance = Random.Range(0, 100);
        if (ScoreValue > 0)
        {
           score.IncreaseScore(ScoreValue);

        }

        if (ChanceDrop > _Chance)
        {
            if (SpawnedObject)
            {
                Instantiate(SpawnedObject, transform.position, Quaternion.identity);
            }
        }

       
            
            SM.ReduceActiveEnemies();
            

        Destroy(this.gameObject);
        }
    }
