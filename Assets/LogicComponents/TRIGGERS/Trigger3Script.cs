using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3Script : MonoBehaviour
{
    public delegate void triggerEvent();
    public event triggerEvent OnTriggerCollide;

   void OnTriggerEnter(Collider other)
    {
        OnTriggerCollide?.Invoke();

    }


}
