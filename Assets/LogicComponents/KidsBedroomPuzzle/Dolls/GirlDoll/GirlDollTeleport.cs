using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlDollTeleport : MonoBehaviour
{
    public int assignedLoop = 4;

    private KidsBedroomTriggerScript triggerForTeleport;

    // Start is called before the first frame update
    void Start()
    {
        if (LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;
        }
        else
        {
            triggerForTeleport = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<KidsBedroomTriggerScript>();
            triggerForTeleport.OnTriggerCollide += teleportGirlDollToHallway;

        }
    }

    private void teleportGirlDollToHallway()
    {
        this.transform.SetParent(GameObject.Find("ApartmentLoop" + assignedLoop + "/Hallway").transform);


        this.transform.localPosition = new Vector3(-7.56f, -10.34f, 17.65f);
        this.transform.localRotation = Quaternion.Euler(new Vector3(0f, 328.58f, 0f));

        triggerForTeleport.OnTriggerCollide -= teleportGirlDollToHallway;


    }
}
