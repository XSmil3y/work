using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript : MonoBehaviour {

    private BoxCollider HitBox;
    public Animator FistAnimator;


    // Use this for initialization
    void Start () {
        HitBox = GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(StartHit());


        }
    }

    IEnumerator StartHit()
    {

        HitBox.enabled = true;
        if (FistAnimator)
        {
            FistAnimator.SetBool("Punch", true);
            
        }

        yield return new WaitForSeconds(.2f);
        
        //Debug.Log("HIT");
        HitBox.enabled = false;

        
        yield return null;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.GetComponent<Health>())
        {
            if (HitBox.enabled == true)
            {
                if (other.tag == "Enemy" || other.tag == "Node")
                    other.transform.gameObject.GetComponent<Health>().Damage(20);
            }
        }
    }

}
