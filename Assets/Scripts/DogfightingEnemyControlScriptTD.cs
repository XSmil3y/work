using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogfightingEnemyControlScriptTD : MonoBehaviour {
    Transform Player;
    GameStateManager GSM;
    Vector3 RelativeRot;
    Quaternion TargetRotation;
    Rigidbody Rb;
    DamageOnTouch Dot;
    
    float _rateOfFire;

    public LaserScript Ls;
    public GameObject Projectile;
    public float Dist;
    public Transform[] Blasters;
    public float speed;
    public float TurningSpeed;
    public float RateOfFire;
    public bool Laser;
    public float LaserChargeRate;
    public float LaserDepletionRate;
    public float LaserCooldown;
    
    private float _LaserCooldown;
    private bool Obstacle;
    private float _TurningSpeed;
    private bool Paused;
    private float _speed;
    private float Charge;
    private bool FiringLaser;
    // Use this for initialization
    void Awake()
    {

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        GSM = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        Rb = this.GetComponent<Rigidbody>();
        _rateOfFire = RateOfFire;

        _speed = Random.Range(10f, speed);
        //Debug.Log(gameObject + " speed: " + _speed);
        _TurningSpeed = Random.Range(.2f, TurningSpeed );
        _LaserCooldown = 0;
        Charge = 0;
       
    }



    public float GetDistance()
    {
        if (Player)
        {
            return Vector3.Distance(transform.position, Player.position);
        }
        else {
            return 0;

        }
    }

    public void CheckMove()
    {
        if (!Paused)
        {
            Rb.AddForce(transform.forward * _speed);
        }
    }
    
    public void Look()
    {
        if (!Paused)
        {

            if (Player)
            {
                RelativeRot = Player.position - transform.position;
                TargetRotation = Quaternion.LookRotation(RelativeRot);
                transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, (_TurningSpeed * Time.deltaTime));
            }
        }
    }

    public void Fire()
    {
        if (!Paused)
        {
            if (!Laser)
            {
                _rateOfFire -= Time.deltaTime;
                if (_rateOfFire <= 0)
                {
                    for (int i = 0; i < Blasters.Length; i++)
                    {

                        GameObject _proj = Instantiate(Projectile, Blasters[i].position, Blasters[i].rotation);
                        _proj.GetComponent<DamageOnTouch>().SetIgnoredObject(gameObject);
                        _rateOfFire = RateOfFire;

                    }
                }
            }

            if (Laser)
            {

                if (_LaserCooldown <= 0)
                {
                    if (!FiringLaser)
                    {
                        if (Charge < 100)
                        {
                            
                            ChargeLaser();
                            Charge += LaserChargeRate;
                        }
                        if (Charge >= 100)
                        {

                          
                            Ls.ToggleLaserON();
                           
                            FiringLaser = true;
                        }
                    }

                    if (FiringLaser)
                    {
                        if (Charge > 0)
                        {

                            Charge -= LaserDepletionRate;

                           
                        }
                        if(Charge <= 0)
                        { _LaserCooldown = LaserCooldown;
                            Ls.ToggleLaserOff();
                            FiringLaser = false;

                          
                        }

                    }

                }
                if(_LaserCooldown > 0)
                {

                   
                    _LaserCooldown -= Time.deltaTime;
                }


                

            }
        }
    }



    public void checkForPause()
    {

       Paused = GSM.GetPaused();
       

    }

    private void ChargeLaser()
    {
        Ls.ChargeLaserEffect();
        Charge += 1;
    }
	
}
