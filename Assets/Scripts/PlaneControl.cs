using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour {

    public float YSensitivity;
    
    public float ZSensitivity;
    public float speed;
    Rigidbody rb;
    Vector3 targetposition;

    float rotationZ;
    float rotationY;
    float GlobalRotX;
    private GameStateManager GSM;
    private bool Paused;

    // Use this for initialization
    void Start () {
        GSM = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        rb = this.GetComponent<Rigidbody>();
	}
	
	// FixedUpdate is called once per frame this is used for ahandling movement that deals with rigidbodies
	
    
    void FixedUpdate()
    {
        Paused = GSM.GetPaused();
        if(!Paused)
        {
            rb.constraints = RigidbodyConstraints.None;
            SetMovement();
            LockedRotation();
            SetYaw();
            rb.rotation = transform.rotation;
        }
        if (Paused)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        
    }

    void LockedRotation()
    {
        rotationZ += Input.GetAxis("Horizontal");
        rotationY += Input.GetAxis("Vertical");

        /*rotationZ = Mathf.Clamp(rotationZ, -90f, 90f);
        rotationY = Mathf.Clamp(rotationY, -50, 50);
        */
        //targetposition = new Vector3(transform.position.x += rotationZ, ( rotationY += transform.position.y), transform.position.z + 5);
        //Vector3.Lerp(transform.position, targetposition, 1f);
        transform.Rotate(Input.GetAxis("Vertical") * (YSensitivity * Time.deltaTime), 0.0f, -Input.GetAxis("Horizontal") * (ZSensitivity * Time.deltaTime));
        
    }

    void SetYaw()
    {
        if(Input.GetAxis("Yaw") > 0f)
        {
            transform.Rotate(0.0f, -.25f , 0.0f);
        }
        if (Input.GetAxis("Yaw") < 0f)
        {
            transform.Rotate(0.0f, .25f, 0.0f);
        }
    }

    void SetMovement()
    {
        if (Input.GetAxis("Acceleration") > 0)
        {
            rb.AddForce(transform.forward * (speed * 1.5f)) ;
        }
        else if (Input.GetAxis("Acceleration") < 0)
        {
            rb.AddForce(transform.forward * (speed * .5f));
        }
        else
        {
            rb.AddForce(transform.forward * speed);
        }
        

    }

}
