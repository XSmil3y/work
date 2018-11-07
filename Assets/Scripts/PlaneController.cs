using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector3 MousePosition;
    public float Acceleration;
    private GameStateManager GSM;
    private bool Paused;

    //public float LevelBoundsX;
    //public float LevelBoundsY;

    // Use this for initialization
    void Start () {
        GSM = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Paused = GSM.GetPaused();

        if (Paused)
        {
            rb.bodyType = RigidbodyType2D.Static;

            return;
        }

        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            TurnPlane();
            MovePlane();
        }

        //RedirectPlane();
	}

    private void TurnPlane()
    {
        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        Vector2 Dir =  new Vector2(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y);

        
        transform.up = Dir;
    }

    private void MovePlane()
    {
       
        float Accel;
        Acceleration = Vector3.Distance(transform.position, (Vector2)MousePosition);
        Accel = Mathf.Clamp(Acceleration, 70, 140);
        Debug.Log(Accel); // fix Later
        rb.AddForce(transform.up * (Accel));
    }

    private void RedirectPlane()
    {
        


    }
}
