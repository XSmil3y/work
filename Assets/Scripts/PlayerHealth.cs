using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;


public class PlayerHealth : MonoBehaviour {
    Score score;

    public GameObject Arms;
    public int InitialHealth;
    public int CurrentHealth;
    public int MaxHealth;
    public int ScoreValue;
    public HealthObject playerHealth;
    private FirstPersonController FPS;
    public Camera PlayerCam;
    private Animator PlayerCamAnimator;
     

    private GameStateManager GSM;
    private bool Paused;

    private void Start()
    {
        CurrentHealth = InitialHealth;
        if (PlayerCam)
        {
            if (PlayerCam.GetComponent<Animator>())
            {
                PlayerCamAnimator = PlayerCam.GetComponent<Animator>();
            }
        }
        if (PlayerCam.GetComponentInParent<FirstPersonController>())
        {
            FPS = GetComponentInParent<FirstPersonController>();

            
        }
        playerHealth.SetBorisHealth(CurrentHealth);
    }
    
    public void Heal(int HP)
    {
        CurrentHealth += HP;

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        playerHealth.SetBorisHealth(CurrentHealth);
    }

    public void Damage(int Dam)
    {
        CurrentHealth -= Dam;


        playerHealth.SetBorisHealth(CurrentHealth);

        if (CurrentHealth <= 0)
        {
                Kill();
        }
        
    }

    public void Kill()
    {
        if (PlayerCamAnimator)
        {
            Arms.SetActive(false);

            FPS.enabled = false;
            PlayerCamAnimator.enabled = true;
            PlayerCamAnimator.SetTrigger("PlayerIsDead");

            
        }
        
        //play the death animation, fade the screen to black, 
        //and store the score in a scriptable object, load a new scene to display the high scores.
        //with the new score on the bottom.
    }
}


