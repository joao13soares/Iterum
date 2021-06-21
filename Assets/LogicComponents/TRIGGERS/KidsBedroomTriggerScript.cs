using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidsBedroomTriggerScript : MonoBehaviour
{

    public delegate void TriggerEvent();
    public event TriggerEvent OnTriggerCollide, OnTriggerLeave;

  

   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnTriggerCollide?.Invoke();

        }

    }

    void OnTriggerExit()
    {

        OnTriggerLeave?.Invoke();
    }
}
