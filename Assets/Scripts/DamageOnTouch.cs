using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour {

    public LayerMask TargetLayers;
    public bool DamageOnStay;
    public bool DestroyOnTouch;
    public int DamageCaused;

    private GameObject IgnoredObject;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // Debug.Log("Collision");
        if (collision.gameObject)
        {
            

            if (collision.GetComponent<Health>())
            {
               
                collision.GetComponent<Health>().Damage(DamageCaused);

                if (DestroyOnTouch)
                {
                    Destroy(this.gameObject);
                }
            }

            if (collision.GetComponent<PlaneHealth>())
            {

                collision.GetComponent<PlaneHealth>().Damage(DamageCaused);

                if (DestroyOnTouch)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        // Debug.Log("Collision");
        

            if (TargetLayers == (TargetLayers | (1 << collision.gameObject.layer)))
            {

               // Debug.Log(collision);
                if (collision.GetComponent<Health>())
                {
                    collision.GetComponent<Health>().Damage(DamageCaused);
                }
                if (collision.GetComponent<PlayerHealth>())
                {
                    collision.GetComponent<PlayerHealth>().Damage(DamageCaused);
                }
                if (collision.GetComponent<PlaneHealth>())
                {
                    collision.GetComponent<PlaneHealth>().Damage(DamageCaused);
                }
                if (collision.GetComponent<ShipHealth>())
                {
                collision.GetComponent<ShipHealth>().Damage(DamageCaused);
                }
            }
        
        if (DestroyOnTouch)
        {
            Destroy(this.gameObject);

        }
        
    }

   private void OnTriggerStay(Collider collision)
    {
        if (DamageOnStay)
        {
            if (collision.GetComponent<Health>())
            {
                collision.GetComponent<Health>().Damage(1);
            }
            if (collision.GetComponent<PlayerHealth>())
            {
                collision.GetComponent<PlayerHealth>().Damage(1);
            }
            if (collision.GetComponent<PlaneHealth>())
            {
                collision.GetComponent<PlaneHealth>().Damage(1);
            }
            if (collision.GetComponent<ShipHealth>())
            {
                collision.GetComponent<ShipHealth>().Damage(1);
            }
        }
    }

    public void SetIgnoredObject(GameObject go)
    {
        IgnoredObject = go;
        //Debug.Log(IgnoredObject);
    }

}
