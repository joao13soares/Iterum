using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidsBedroomDoorBehaviour : MonoBehaviour
{

    public int assignedLoop = 4;

    public AudioClip openSound;

    private Trigger3Script triggerScriptForOpenDoor;

    // Start is called before the first frame update
    void Start()
    {
        if(LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;

        }
        else
        {

            triggerScriptForOpenDoor = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<Trigger3Script>();
            triggerScriptForOpenDoor.OnTriggerCollide += openDoor;
        }


    }

   
    private void openDoor()
    {
        this.GetComponent<Animation>().Play("OpenNormalDoor");

        this.GetComponent<AudioSource>().PlayOneShot(openSound, 1f);

        this.GetComponent<DoorShaking>().canInteract = false;

        triggerScriptForOpenDoor.OnTriggerCollide -= openDoor;

    }

}
