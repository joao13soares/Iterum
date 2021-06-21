using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoorBehaviour : MonoBehaviour
{
    public int assignedLoop = 1;
    public AudioClip openSound, closeSound;

    private Trigger1Script openDoorTrigger;
    private KitchenPlaceHolder puzzleEvent;

    // Start is called before the first frame update
    void Start()
    {
        if (LoopCounter.LoopNumber == assignedLoop)
        {

            // Takes care of opening and closing door during puzzle
            puzzleEvent = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<KitchenPlaceHolder>();

            puzzleEvent.startPuzzleEvent += closeDoor;
            puzzleEvent.endPuzzleEvent += openDoorEndPuzzle;


            // Open kitchen door when walking through corridor trigger
            openDoorTrigger = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<Trigger1Script>();

            openDoorTrigger.onTriggerCollide += openDoorOnTrigger;

            Debug.Log("COZINHA ABRIU");

        }
    }



    void openDoorOnTrigger()
    {
        this.GetComponent<Animation>().Play("OpenNormalDoor");

        this.GetComponent<AudioSource>().PlayOneShot(openSound, 1f);

        this.GetComponent<DoorShaking>().canInteract = false;

        openDoorTrigger.onTriggerCollide -= openDoorOnTrigger;


    }

    void openDoorEndPuzzle()
    {
        this.GetComponent<Animation>().Play("OpenNormalDoor");

        this.GetComponent<AudioSource>().PlayOneShot(openSound, 1f);

        this.GetComponent<DoorShaking>().canInteract = false;
        
        puzzleEvent.endPuzzleEvent -= openDoorEndPuzzle;

    }

    void closeDoor()
    {

        this.GetComponent<Animation>().Play("CloseNormalDoor");

        this.GetComponent<AudioSource>().PlayOneShot(closeSound, 1f);

        this.GetComponent<DoorShaking>().canInteract = true;

        puzzleEvent.startPuzzleEvent -= closeDoor;


    }
}
