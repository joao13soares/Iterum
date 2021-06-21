using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop4Blackout : MonoBehaviour
{
    public int assignedLoop = 4;

    KidsBedroomTriggerScript triggerScriptForBlackout;


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
            triggerScriptForBlackout = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<KidsBedroomTriggerScript>();

            // Sets up functions on events
            triggerScriptForBlackout.OnTriggerCollide += blackout;
            triggerScriptForBlackout.OnTriggerLeave += turnBackOn;


        }
    }

    private void blackout()
    {
        // Turns of lights and disables func from event
        this.GetComponent<Light>().intensity = 0f;
        triggerScriptForBlackout.OnTriggerCollide -= blackout;

    }

    private void turnBackOn()
    {
        // Turns of lights and disables func from event
        this.GetComponent<Light>().intensity = 1f;
        triggerScriptForBlackout.OnTriggerLeave -= turnBackOn;

    }
}
