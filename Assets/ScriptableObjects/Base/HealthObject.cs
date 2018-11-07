using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthObject", menuName = "HealthObject/PlayerHealth", order = 1)]
public class HealthObject : ScriptableObject {
    public int BorisHealth;

    public int DimitriHealth;

    public int BorisLives;

    private int _borisHealth;
    private int _dimitriHealth;
    private int _borisLives;


    /*void OnAwake()
    {
        _borisHealth;
        _dimitriHealth;
        _borisLives;
    }   
    */
    public int GetBorisHealth()
    {
        return BorisHealth;
    }

    public void SetBorisHealth(int NewValue)
    {
        BorisHealth = NewValue;
    }

    public int GetDimitriHealth()
    {
        return DimitriHealth;
    }

    public void SetDimitriHealth(int NewValue)
    {
        DimitriHealth = NewValue;
    }




}
