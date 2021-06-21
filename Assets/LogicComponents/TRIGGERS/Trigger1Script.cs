using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1Script : MonoBehaviour
{

    public delegate void Trigger();

    public event Trigger onTriggerCollide;

    public event Trigger onTriggerLeave;

  

   void OnTriggerEnter(Collider other)
    {
        onTriggerCollide?.Invoke();

    }

    void OnTriggerExit(Collider other)
    {
        onTriggerLeave?.Invoke();
    }
}
