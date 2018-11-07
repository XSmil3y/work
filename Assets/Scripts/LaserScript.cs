using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {
    public GameObject Laser;
    public float MaxLineDistance;
    public ParticleSystem LaserParticleEffect;
    public ParticleSystem ChargeParticleEffect;
    public AudioClip LaserSound;
    public AudioClip ChargeSound;
    public float CurrentLineDistance;


    public bool TestBool;

    public AudioSource LaserFireAudioSource;
    public AudioSource LaserChargeAudioSource;
    public LineRenderer LaserLine;
    BoxCollider LaserCol;
    bool LaserOn;
    float[] x = new float[4];
    float Y;
    Vector3 ColSize;
    Vector3 ColCenter;

    Vector3[] Position = new Vector3[4];

    int PositionsNum;

    
	// Use this for initialization
	void Start () {
        //ParticleEffect.Stop();
        LaserLine = Laser.GetComponent<LineRenderer>();
        LaserCol = Laser.GetComponent<BoxCollider>();
       ;
       // ToggleLaserOff();
        
        for(int i = 0; i < 4; i++)
        {

            x[i] = 0;
            Position[i] = new Vector3(0, 0, 0);
        }

        CurrentLineDistance = .01f;
        LaserLine.positionCount = 4;
        
	}
	
	// Update is called once per frame
	void Update () {

       /* if (TestBool)
        {
            ToggleLaserON();
        }

        if(!TestBool)
        {
           ToggleLaserOff();
        }
        */

        if (LaserOn)
        {
            if (CurrentLineDistance < MaxLineDistance)
            {
               
                CurrentLineDistance += 10;
            }

            CalculateLineLength();
            SetLength();
        }
        if (!LaserOn)
        {
           
        }
	}

    void CalculateLineLength()
    {
        
        for(int i = 0; i < 4; i++)
        {
            x[i] = (CurrentLineDistance / 4) * i; 
            Position[i] = new Vector3(0, Y, x[i]);

        }
       
    }

    void SetLength()
    {
        for(int i = 0; i < 4; i++)
        {
            
            LaserLine.SetPosition(i, Position[i]);
            
        }

        ColSize = new Vector3(LaserCol.size.x, LaserCol.size.y, Position[3].z);
        ColCenter = new Vector3(LaserCol.center.x, LaserCol.center.y,(Vector3.Distance(Position[0], ColSize))/2);
        LaserCol.center = ColCenter;
        LaserCol.size = ColSize;
    }

    public void ChargeLaserEffect()
    {
        if (LaserFireAudioSource)
        {
            if (!LaserFireAudioSource.isPlaying)
            {
                LaserChargeAudioSource.Play();
                LaserFireAudioSource.PlayDelayed(LaserChargeAudioSource.clip.length);

                LaserLine.enabled = false;
            }
        }
        /* ChargeParticleEffect.Play();
         if (!AS.isPlaying) {
             AS.loop = false;
             AS.PlayOneShot(ChargeSound);
         }
         */
    }

    public void ToggleLaserON()
    {
        if (ChargeParticleEffect)
        {
            if (ChargeParticleEffect.isPlaying)
            {
                ChargeParticleEffect.Stop();
            }


            LaserOn = true;



            LaserLine.enabled = true;



            LaserCol.enabled = true;



            LaserParticleEffect.Play();

        }
    }


    public void ToggleLaserOff()
    {
        CurrentLineDistance = 0.1f;
        ColSize = new Vector3(LaserCol.size.x, LaserCol.size.y, 0.01f);
        LaserCol.enabled = false;
        LaserOn = false;
        LaserLine.enabled = false;
        LaserParticleEffect.Stop();

        LaserFireAudioSource.Stop();
    }

}
