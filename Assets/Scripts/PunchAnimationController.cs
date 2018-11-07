using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAnimationController : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
       anim = this.GetComponent<Animator>();
	}
	
	public void SetAnimBool()
    {
        anim.SetBool("Punch", false);
    }
}
