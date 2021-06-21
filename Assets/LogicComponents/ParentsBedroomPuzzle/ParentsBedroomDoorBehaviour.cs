using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsBedroomDoorBehaviour : MonoBehaviour
{
    public int assignedLoop = 2;

    public AudioClip openDoorSound, closeDoorSound;

    private Trigger1Script triggerForOpenDoor;
    private LighterBehaviour lighterEventForCloseDoor;
    private DoorShaking spawnGirlEventScript;


    // Start is called before the first frame update
    void Start()
    {
        // Starts door open only in Loop 1
        if (LoopCounter.LoopNumber == assignedLoop)
        {
            // hall trigger opens ParentsBedroomDoor onTriggerLeave
            triggerForOpenDoor = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<Trigger1Script>();
            triggerForOpenDoor.onTriggerLeave += openDoorToEnter;

            // Lighter closes ParentsBedroomDoor onPickUp & does lighterEnabledInteract()
            lighterEventForCloseDoor = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<LighterBehaviour>();
            lighterEventForCloseDoor.onPickUp += closeDoor;
            lighterEventForCloseDoor.onTurnOn += lighterEnabledInteract;

          
            // Gets Player lookAtGirlEvent to open ParentsBedroomDoor
            GameObject.Find("Player_1").GetComponent<DetectLookAtGirl>().OnLookAtGirlEvent += openDoorToLeave;

        }
    }

    private void openDoorToEnter()
    {
        // Open animation and sound
        this.GetComponent<Animation>().Play("OpenNormalDoor");
        this.GetComponent<AudioSource>().PlayOneShot(openDoorSound);

        this.GetComponent<DoorShaking>().canInteract = false;

        triggerForOpenDoor.onTriggerLeave -= openDoorToEnter;
    }

    private void openDoorToLeave()
    {
        // Open animation and sound
        this.GetComponent<Animation>().Play("OpenNormalDoor");
        this.GetComponent<AudioSource>().PlayOneShot(openDoorSound);

        this.GetComponent<DoorShaking>().canInteract = false;

        GameObject.Find("Player_1").GetComponent<DetectLookAtGirl>().OnLookAtGirlEvent -= openDoorToLeave;

    }

    private void closeDoor()
    {
        // Closed animation and sound
        this.GetComponent<Animation>().Play("CloseNormalDoor");
        this.GetComponent<AudioSource>().PlayOneShot(closeDoorSound);

    }

    // this allows player to interact with ParentsBedroomDoor only after turning on the Lighter
    private void lighterEnabledInteract()
    {
        this.GetComponent<DoorShaking>().canInteract = true;

        // spawn girl after SUCCESSFULLY interact with ParentsBedroomDoor
        spawnGirlEventScript = this.GetComponent<DoorShaking>();
        spawnGirlEventScript.onDoorInteractEvent += spawnGirlBedroom;

        // Unsubscribe
        lighterEventForCloseDoor.onTurnOn -= lighterEnabledInteract;

    }

    private void spawnGirlBedroom()
    {
        // move girl to ParentsBedroom
        Vector3 position = GameObject.Find("ApartmentLoop" + assignedLoop).transform.position + new Vector3(2.165f, -3.023f, -19.01f);
        GameObject.Find("Silhouette(Clone)").transform.position = position;
        GameObject.Find("Silhouette(Clone)").transform.rotation = Quaternion.Euler(new Vector3(0f, -75f, 0f));





        spawnGirlEventScript.onDoorInteractEvent -= spawnGirlBedroom;
    }
}
