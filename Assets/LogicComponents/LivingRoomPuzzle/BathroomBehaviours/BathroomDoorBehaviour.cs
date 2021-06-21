using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class BathroomDoorBehaviour : MonoBehaviour
{
    // VERDADEIRO É 3
    public int assignedLoop = 1;

    public AudioClip openDoorSound;
    private TVScreenBehaviour tvEventScriptForOpen;

    // Start is called before the first frame update
    void Start()
    {

        if (LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;

        }
        else
        {
            tvEventScriptForOpen = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<TVScreenBehaviour>();
            tvEventScriptForOpen.OnTurnOffTV += openDoor;



        }
    }

    private void openDoor()
    {
        // Open animation and sound
        this.GetComponent<Animation>().Play("OpenNormalDoor");
        this.GetComponent<AudioSource>().PlayOneShot(openDoorSound);

        this.GetComponent<DoorShaking>().canInteract = false;

        tvEventScriptForOpen.OnTurnOffTV -= openDoor;

    }
}
