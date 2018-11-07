using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FPS_EnemyControlScript : MonoBehaviour {
      
    NavMeshAgent nav;
    public BoxCollider HitBox;
    public LayerMask TargetLayerMask;
    Transform Target;
    private RaycastHit hit;
    public GameObject Bullet;
    public GameObject WeaponHolder;
    private bool Call;
    public float cooldown;
    private float _cooldown;
	// Use this for initialization
	void Awake () {
        InitializeVariables();
	}
	
	// Update is called once per frame
	void Update () {
        if (!nav.isOnNavMesh)
        {
            gameObject.GetComponent<Health>().Kill();
            
        }

        //Debug.Log(_cooldown);
	}

     void InitializeVariables()
    {
        nav = GetComponent<NavMeshAgent>();
        Target = GameObject.Find("Player").transform;

    }
    private void GetTargetPosition()
    {
        //Target.position;
    }

    public void MeleeAttackAI()
    {
        if (Target)
        {
            if (nav.isOnNavMesh)
            {
                nav.SetDestination(Target.position);
                if (Vector3.Distance(this.transform.position, Target.position) <= nav.stoppingDistance)
                {
                    if (_cooldown <= 0)
                    {

                        Call = true;

                        if (Call)
                        {
                            StartCoroutine(StartHit());
                            Call = false;
                        }

                    }
                    else
                    {
                        _cooldown -= Time.deltaTime;
                    }
                  
                }
            }
        }
    
    }

    IEnumerator StartHit()
    {
        
            HitBox.enabled = true;
            yield return new WaitForSeconds(.2f);

            HitBox.enabled = false;

        _cooldown = cooldown;
        Call = true;

        yield return 0;

    }

    private void OnTriggerEnter(Collider other)
    {
        
          //  Debug.Log("a");
            if (other.tag == "Player")
            {
                if (other.transform.gameObject.GetComponent<PlayerHealth>())
                {
              //  Debug.Log("B");
                other.transform.gameObject.GetComponent<PlayerHealth>().Damage(5);
                }if (other.tag == "Enemy")
                {
                return;
                }
            }
    }

    public void RangedAttackAI()
    {
        if (Target)
        {
            if (nav.isOnNavMesh)
            {
                nav.SetDestination(Target.position);
            }

           /*if (hit.collider)
            {

                //if (Hit.collider.tag == "Player")
              //  {
                    nav.isStopped = true;
                    
                //}

            }
            */

             //shoot
            if (_cooldown <= 0)
            {


                shootGun();
                _cooldown = cooldown;
            }

            else { _cooldown -= Time.deltaTime; }

            transform.LookAt(Target);
        }


        else
        {
           

        }
    }
    



    private void shootGun()
    {
        
        Instantiate(Bullet, WeaponHolder.transform.position, WeaponHolder.transform.rotation);
    }



    
}
