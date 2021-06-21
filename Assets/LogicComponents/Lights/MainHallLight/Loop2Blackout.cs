using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop2Blackout : MonoBehaviour
{
    public int assignedLoop = 2;

    Trigger1Script triggerForBlackoutLoop2;
    LighterBehaviour lighterEventForBedroomEvents;
    DetectLookAtGirl lookAtGirlBedroomBlackoutEvent;


    // Start is called before the first frame update
    void Start()
    {
        if (LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;
        }
        else
        {
            // Gets trigger 1 of respective loop
            triggerForBlackoutLoop2 = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<Trigger1Script>();

            // Sets up functions on events
            triggerForBlackoutLoop2.onTriggerCollide += blackoutHall;
            triggerForBlackoutLoop2.onTriggerLeave += turnOnHall;


            // Gets Lighter event of respective loop
            lighterEventForBedroomEvents = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<LighterBehaviour>();

            // Sets up functions on events
            lighterEventForBedroomEvents.onPickUp += blackoutBedroom;

            // Gets Player lookAtGirlEvent to blackoutBedroom
            lookAtGirlBedroomBlackoutEvent = GameObject.Find("Player_1").GetComponent<DetectLookAtGirl>();
            lookAtGirlBedroomBlackoutEvent.OnLookAtGirlEvent += blackoutBedroom;
        }
    }

    private void blackoutHall()
    {
        // Turns of lights and disables func from event
        this.GetComponent<Light>().intensity = 0f;
        triggerForBlackoutLoop2.onTriggerCollide -= blackoutHall;

    }

    private void turnOnHall()
    {
        // turns on lights and disables func from event
        this.GetComponent<Light>().intensity = 2f;
        triggerForBlackoutLoop2.onTriggerLeave -= turnOnHall;

    }

    
    // happens after picking up Lighter
    private void blackoutBedroom()
    {
        // Turns of lights and disables func from event
        this.GetComponent<Light>().intensity = 0f;
        lookAtGirlBedroomBlackoutEvent.OnLookAtGirlEvent -= blackoutBedroom;

    }

 
}
