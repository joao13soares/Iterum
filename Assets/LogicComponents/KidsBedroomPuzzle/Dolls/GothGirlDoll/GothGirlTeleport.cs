using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GothGirlTeleport : MonoBehaviour
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
            triggerForTeleport.OnTriggerCollide += teleportGothGirlToHallway;

        }
    }

    private void teleportGothGirlToHallway()
    {
        this.transform.SetParent(GameObject.Find("ApartmentLoop" + assignedLoop + "/Hallway").transform);

        
        this.transform.localPosition = new Vector3(-11.64f, -10.45f, 9.78f);
        this.transform.localRotation = Quaternion.Euler(new Vector3(6.3f, 214f, 0.17f));

        triggerForTeleport.OnTriggerCollide -= teleportGothGirlToHallway;


    }
}
