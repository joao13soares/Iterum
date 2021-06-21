using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2Script : MonoBehaviour
{
    public delegate void triggerEvent();
    public event triggerEvent onTriggerCollide;

    void OnTriggerEnter(Collider other)
    {
        onTriggerCollide?.Invoke();

    }
    
}
