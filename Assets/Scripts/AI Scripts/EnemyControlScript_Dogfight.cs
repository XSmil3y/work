using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlScript_Dogfight : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector3 MousePosition;

    public int LaserDamage;

    public LineRenderer LR;
    public LayerMask TargetLayerMask;

    private GameStateManager GSM;
    private bool Paused;
    private Transform Target;
    public Vector3 TargetPos;
    public float _DistToTarget;
    public GameObject Projectile;

    public float Firecooldown = .4f;
    private float _Cooldown;

    public float BuildUp;
    private float _BuildUp;

    public float LaserActiveTime;
    private float _LaserActiveTime;

    public float VisibleRadius;
    public float Speed;
    public float MiniumRadius;
    public GameObject WeaponHolder;

   private float TargetX = 0;
   private float TargetY = 0;


    // Use this for initialization
    void Awake () {
        InitializeVariables();
	}
	
	// Update is called once per frame
	void Update () {
        Paused = GSM.GetPaused();

        if (Paused)
        {

        }

        if (!Paused)
        {

        }
	}

    private void InitializeVariables()
    {

        GSM = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        rb = GetComponent<Rigidbody2D>();
        Target = GameObject.Find("Player").transform;
        _Cooldown = Firecooldown;
        if (LR)
        {
            LR.enabled = false;
        }

        

        
        
    }

    public void GetTargetPos()
    {
        TargetPos = Target.position;
        _DistToTarget = Vector3.Distance(transform.position, Target.position);

    }

    public void TurnShip()
    {
        Vector2 Dir = new Vector2(TargetPos.x - transform.position.x, TargetPos.y - transform.position.y);
        transform.up = Dir;
    }

    public void TurnShipSlowly()
    {
        /*

        if (TargetPos.x < transform.position.x)
        {
            TargetX -= 1;

            if (TargetY < -10)
            {
                TargetY = -10;
            }
        }

        else if(TargetPos.x >= transform.position.x)
        {
            TargetX += 1;
        }

        if (TargetPos.y < transform.position.y)
        {
            TargetY -= 1;

            if (TargetY < -10)
            {
                TargetY = -10;
            }
        }
        else if (TargetPos.y >= transform.position.y)
        {
            TargetY += 1;

            if (TargetY > 10)
            {
                TargetY = 10;
            }

        }
*/
       // Debug.Log("TargetX" + TargetX);

       // Debug.Log("TargetY" + TargetY);

        Vector2 Dir = new Vector2(TargetPos.x - transform.position.x, TargetPos.y - transform.position.y);
        transform.up = Dir;
    }

     public void MoveShip()
    {
        float Acceleration = Vector3.Distance(transform.position, TargetPos);
        Mathf.Clamp(Acceleration, 1, 20);

        rb.AddForce(transform.up * Acceleration);
    }

    public void MoveShipAway()
    {
        float Acceleration = Vector3.Distance(transform.position, TargetPos);
        Mathf.Clamp(Acceleration, 1, 10);

        rb.AddForce(-transform.up * Acceleration);
    }

    //Create a function that Shoots Projectiles, Rockets, and Lasers
    public void ShootProjectile()
    {
       if(_Cooldown <= 0)
        {

            Instantiate(Projectile, WeaponHolder.transform.position, transform.rotation);
            _Cooldown = Firecooldown;
        }
        _Cooldown -= Time.deltaTime;

    }

    public void ShootLaser()
    {
        
        if (_Cooldown <= 0)
        {
           // Debug.Log("A");
            if (_BuildUp >= BuildUp)
            {
                LR.enabled = true;
              //  Debug.Log("b");
                RaycastHit2D hit = Physics2D.Raycast(WeaponHolder.transform.position, transform.up, 300, TargetLayerMask);
                
                LR.SetPosition(0, WeaponHolder.transform.position);
                if (hit)
                {
                   // Debug.Log("D");
                    float newDist =Vector3.Distance(transform.position, hit.transform.position);
                    LR.SetPosition(1, hit.transform.position);
                    if (hit.transform.GetComponent<Health>())
                    {
                        hit.transform.GetComponent<Health>().Damage(LaserDamage);
                    }
                }
                else
                {
                    LR.SetPosition(1, transform.up * 300);
                }


                if (_LaserActiveTime >= LaserActiveTime)
                {
                   // Debug.Log("c");
                    _Cooldown = Firecooldown;
                    _BuildUp = 0;
                    _LaserActiveTime = 0;
                    StopLaser();
                }

                else
                {
                    _LaserActiveTime += Time.deltaTime;
                }


            }

            else
            {
                _BuildUp += Time.deltaTime;
            }
        }

        else
        {
            _Cooldown -= Time.deltaTime;
        }

        

    }

    public void StopLaser()
    {
        LR.enabled = false;
    }

    //create an alternate function that turns the Larger ships that shoot lasers more slowly

    public bool GetIsPaused()
    {
        return GSM.GetPaused();
    }

    public bool DecideToChase()
    {
        if (_DistToTarget > VisibleRadius)
        {
            return true;
        }
        else
        {
            return false;

        }
    }

    public bool DecideToStop()
    {
        if (_DistToTarget <= MiniumRadius)
        {
            return true;
        }
        else return false;
    }

    public bool DecideToFlee()
    {
        if (_DistToTarget <= MiniumRadius - 2)
        {
            return true;
        }
        else return false;
    }

    public bool DecideToStopFleeing()
    {
        if (_DistToTarget > MiniumRadius + 2)
        {
            return true;
        }
        return false;
    }

    public void setDynamic()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void SetStatic()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }

}
