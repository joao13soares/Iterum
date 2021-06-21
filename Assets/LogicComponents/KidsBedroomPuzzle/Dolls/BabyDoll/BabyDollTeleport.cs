using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDollTeleport : MonoBehaviour
{
    
    public int assignedLoop = 4;

    private KidsBedroomTriggerScript triggerForTeleport;


    void Start()
    {
        if (LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;
        }
        else
        {

            triggerForTeleport = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<KidsBedroomTriggerScript>();
            triggerForTeleport.OnTriggerCollide += teleportBabyDollToHallway;

        }
    }

    private void teleportBabyDollToHallway()
    {
        this.transform.SetParent(GameObject.Find("ApartmentLoop" + assignedLoop + "/Hallway").transform);


        this.transform.localPosition = new Vector3(-15.14f, -10.58f, -5.02f);
        this.transform.localRotation = Quaternion.Euler(new Vector3(0f, 51.5f, 0f));


        triggerForTeleport.OnTriggerCollide -= teleportBabyDollToHallway;


    }


}
