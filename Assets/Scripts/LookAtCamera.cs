using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    Transform CameraTransform;
	// Use this for initialization
	void Start () {
        CameraTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(CameraTransform);
	}
}
