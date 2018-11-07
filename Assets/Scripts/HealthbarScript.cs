using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour {
    private int _Health;
    private int _Strength;
    private float _PlaneHealth;

    public HealthObject playerHealth;
    public Image PlaneHealthSlider;
    public Text BorisHealthText;
    public Text BorisStrengthText;

	
	
	
	// Update is called once per frame
	void Update () {
        GetHealth();
        UpdateUi();
	}

    private void GetHealth()
    {
        _Health = playerHealth.GetBorisHealth();
        _PlaneHealth = (playerHealth.GetDimitriHealth() *.01f);
    }

    private void UpdateUi()
    {
        BorisHealthText.text = _Health.ToString();
        PlaneHealthSlider.fillAmount = _PlaneHealth;
    }
}
