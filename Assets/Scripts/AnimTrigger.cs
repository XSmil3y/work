using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class AnimTrigger : MonoBehaviour {
    public Animator NextAnim;
    private int i = 0;
    public RawImage[] Images;
    public GameObject BrokenAnvil;
    public GameObject Nameplate;
    public GameObject FighterPilot;
    public AudioClip Impact;
    public AudioClip Fimpact;
    public AudioClip Airplane;
    public AudioClip TitleOpening;
    public AudioClip TitleLoop;
    public GameObject[] ElementsToHide;

    private AudioSource AS;

    private void Awake()
    {
        AS = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            HideElements();
        }
    }

	public void TriggerNextAnim()
    {
        NextAnim.SetTrigger("Play");
    }

    public void spwanElement()
    {
        Images[i].gameObject.SetActive(true);
        i += 1;
        AS.PlayOneShot(Impact);
    }

    public void SpawnExplosion()
    {
        BrokenAnvil.SetActive(true);
        
        Nameplate.SetActive(true);
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    public void PlayPlaneAudio()
    {
        AS.PlayOneShot(Airplane);
    }

    public void PlayFallImpact()
    {
        AS.PlayOneShot(Fimpact);
    }

    public void PlayMusicOpening()
    {

        AS.PlayOneShot(TitleOpening);
        
        
    }

    public void PlayMusicLoop()
    {
        AS.clip = TitleLoop;
        
        AS.loop = true;
        AS.Play();
    }

    private void HideElements()
    {
        Debug.Log("HideElements");

        SceneManager.LoadScene("3D DogFighting Scene", LoadSceneMode.Single);
        /* foreach(GameObject element in ElementsToHide)
         {
             element.SetActive(false);
         }*/
    }
}
