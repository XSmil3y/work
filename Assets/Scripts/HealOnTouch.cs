using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOnTouch : MonoBehaviour {


    public LayerMask TargetLayers;
    public int Heals;
    public bool DestroyOnTouch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Collision");
        if (collision.gameObject)
        {

            if (collision.GetComponent<Health>())
            {
                collision.GetComponent<Health>().Heal(Heals);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Debug.Log("Collision");
        if (collision.gameObject)
        {

            if (collision.GetComponent<PlayerHealth>() )
            {
                collision.GetComponent<PlayerHealth>().Heal(Heals);
                if (DestroyOnTouch)
                {
                    Destroy(this.gameObject);
                }
            }

            if (collision.GetComponent<PlaneHealth>())
            {
                collision.GetComponent<PlaneHealth>().Heal(Heals);
                if (DestroyOnTouch)
                {
                    Destroy(this.gameObject);
                }
            }
            
        }
    }


}
