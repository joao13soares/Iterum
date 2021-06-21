using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashaTeleport : MonoBehaviour
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
            Debug.Log("PRONTO PO TP");
            triggerForTeleport = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<KidsBedroomTriggerScript>();
            triggerForTeleport.OnTriggerCollide += teleportMashaToHallway;

        }
    }

    private void teleportMashaToHallway()
    {
        this.transform.SetParent(GameObject.Find("ApartmentLoop" + assignedLoop + "/Hallway").transform);


        this.transform.localPosition = new Vector3(-4.4f, -10.57f, -1.51f);
        this.transform.localRotation = Quaternion.Euler(new Vector3(0f, -5.5f, 0f));

        triggerForTeleport.OnTriggerCollide -= teleportMashaToHallway;


    }
}
