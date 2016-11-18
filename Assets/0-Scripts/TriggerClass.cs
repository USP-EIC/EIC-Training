using System;
using UnityEngine;
using System.Collections;

public class TriggerClass
{

    public GameObject Trigger;
    public bool Active;

    public TriggerClass(GameObject obje, bool active = false)
    {
        Trigger = obje;
        Active = active;
    }
}
