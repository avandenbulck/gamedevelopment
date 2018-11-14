using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeUpBar : MonoBehaviour {

    public Done_PlayerController player;

    private Slider slider;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
	}
	
    public void OnChargeChanged()
    {
        slider.value = player.getCurrentChargeValue() / 100;
    }
	
}
