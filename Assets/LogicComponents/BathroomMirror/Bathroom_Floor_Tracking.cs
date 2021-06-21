using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom_Floor_Tracking : MonoBehaviour
{
    public int assignedLoop = 3;


    public Vector3 playerPosition;
    private GameObject player;

    public delegate void OnTrigger();
    public event OnTrigger onTriggerEvent;
    private Vector3 apartmentPosition;

    void Start()
    {if(LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;

        }
    else
        {
            player = GameObject.Find("Player_1");
            apartmentPosition = GameObject.Find("ApartmentLoop" + assignedLoop).transform.position;
            

        }
       
    }

    public void OnTriggerEnter(Collider other)
    {

        playerPosition = player.transform.position - (apartmentPosition + this.transform.parent.localPosition);
        
        onTriggerEvent?.Invoke();

    }

    public void OnTriggerStay()
    {
        playerPosition = player.transform.position - (apartmentPosition + this.transform.parent.localPosition);

        onTriggerEvent?.Invoke();
        
        
    }

    public void OnTriggerExit()
    {
        playerPosition = Vector3.zero;
        onTriggerEvent?.Invoke();
    }


}

