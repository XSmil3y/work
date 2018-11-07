using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    float RotSpeed;
	// Use this for initialization
	void Start () {
        RotSpeed = Random.Range(0.5f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0.0f, RotSpeed, 0.0f);
	}
}
