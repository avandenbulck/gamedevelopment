using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public float chargeUpValue;
    private Action<float> chargeUpAction;

    public void SetOnChargeUpAction(Action<float> chargeUpAction)
    {
        this.chargeUpAction = chargeUpAction;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
            chargeUpAction(chargeUpValue);
    }
}