using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile3D : MonoBehaviour {

	

    public float Lifetime = 5;
    public float speed = 5;
    public float Acceleration = 1;


    public float trauma;

    private float _Lifetime;
    private float _speed;

    //private GameStateManager GSM;
    //private bool Paused;
    private Rigidbody rb;
    public ParticleSystem Effect;

    private void Start()
    {
      InitializeValues();
        if (Effect)
        {
            Effect.Play();
        }
    }

    public void InitializeValues()
    {
        _Lifetime = Lifetime;
      
        rb = GetComponent<Rigidbody>();

        _speed = speed * Acceleration;
        
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed);
        
        if (_Lifetime <= 0)
            {
                Kill();
        }
            _Lifetime -= Time.deltaTime;

        
    }

    

   

    public void Kill()
    {
        Destroy(this.gameObject);
    }

   

}


