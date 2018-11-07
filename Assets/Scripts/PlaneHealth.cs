using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHealth : MonoBehaviour {

    SpawnManager SM;
    Animator Cam;
    public GameObject PlaneController;
    public HealthObject playerHealth;
    Score score;

    public int InitialHealth;
    public int CurrentHealth;
    public int MaxHealth;
    public int ScoreValue;

    private GameStateManager GSM;
    private bool Paused;

    private void Start()
    {
        Cam = Camera.main.GetComponent<Animator>();

        if (GameObject.Find("SpawnPoints"))
        {
            SM = GameObject.Find("SpawnPoints").GetComponent<SpawnManager>();
        }
        CurrentHealth = InitialHealth;
        score = Camera.main.GetComponentInChildren<Score>();

        playerHealth.SetDimitriHealth(CurrentHealth);

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
        playerHealth.SetDimitriHealth(CurrentHealth);
    }

    public void Damage(int Dam)
    {
        CurrentHealth -= Dam;

        {
            if (CurrentHealth <= 0)
            {
                Debug.Log(CurrentHealth);
                //kill player, Show GameOver
            }

            playerHealth.SetDimitriHealth(CurrentHealth);

            if (CurrentHealth <= 0)
            {
                Kill();
            }

        }
    }

    public void Kill()
    {
        // score.IncreaseScore(ScoreValue);
        Destroy(PlaneController);
        Destroy(this.gameObject);
        Cam.SetTrigger("PlaneDestroyed");
    }
}
