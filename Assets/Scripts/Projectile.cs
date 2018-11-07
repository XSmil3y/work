using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float Lifetime = 5;
    public float speed = 5;
    public float Acceleration = 1;
   

    public float trauma;

    private float _Lifetime;
    private float _speed;

    private GameStateManager GSM;
    private bool Paused;
    private Rigidbody2D rb;
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
        GSM = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        rb = GetComponent<Rigidbody2D>();

        _speed = speed * Acceleration;
        rb.AddForce(transform.up * _speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        Paused = GSM.GetPaused();
        if (!Paused)
        {
            UpdatePosition();
            if(_Lifetime <= 0)
            {
                Kill();
            }
            _Lifetime -= Time.deltaTime;

        }
    }

    private void UpdatePosition()
    {
       
    }

    public void Kill()
    {
        Destroy(this.gameObject);
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
