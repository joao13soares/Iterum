using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHallDoorBehaviour : MonoBehaviour
{
    public int assignedLoop = 1;
    private float openAngle = 120f;
    private DoorShaking mainHallDoorShakingScript;

    public AudioClip openMainDoorSound, closeMainDoorSound;

    Trigger1Script triggerCloseDoor;
    KitchenPlaceHolder eventOpenDoor;

    // Start is called before the first frame update
    void Start()
    {

        mainHallDoorShakingScript = this.GetComponent<DoorShaking>();

        switch (LoopCounter.LoopNumber)
        {
            case 1:
                loop1Init();
                break;

            case 2:
                loop2Init();
                break;

            case 3:
                loop3Init();
                break;

            case 4:
                loop4Init();
                break;

        }



    }


    private void loop1Init()
    {


        // Spawns door already open
        Vector3 openTranform = new Vector3(0f, openAngle, 0f);
        this.transform.localEulerAngles = openTranform;

        // Subscribes for trigger to close door when player gets nearby
        triggerCloseDoor = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<Trigger1Script>();
        triggerCloseDoor.onTriggerCollide += closeDoorLoop1;


        // Subscribe for event to open door when puzzle is finished
        eventOpenDoor = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<KitchenPlaceHolder>();
        eventOpenDoor.endPuzzleEvent += openDoorLoop1;
    }

    public void closeDoorLoop1()
    {
        // Closed animation and sound
        this.GetComponent<Animation>().Play("CloseMainDoor");
        this.GetComponent<AudioSource>().PlayOneShot(closeMainDoorSound);

        triggerCloseDoor.onTriggerCollide -= closeDoorLoop1;

        mainHallDoorShakingScript.canInteract = true;



    }

    private void openDoorLoop1()
    {
        // Open animation and sound
        this.GetComponent<Animation>().Play("OpenMainDoor");
        this.GetComponent<AudioSource>().PlayOneShot(openMainDoorSound);

        eventOpenDoor.endPuzzleEvent -= openDoorLoop1;

        mainHallDoorShakingScript.canInteract = false;


    }





    private void loop2Init()
    {
        GameObject.Find("Player_1").GetComponent<DetectLookAtGirl>().OnLookAtGirlEvent += openDoorLoop2;

    }
   
    private void openDoorLoop2()
    {
        // Open animation and sound
        this.GetComponent<Animation>().Play("OpenMainDoor");
        this.GetComponent<AudioSource>().PlayOneShot(openMainDoorSound);

        GameObject.Find("Player_1").GetComponent<DetectLookAtGirl>().OnLookAtGirlEvent -= openDoorLoop2;

        mainHallDoorShakingScript.canInteract = false;


    }

    private void loop3Init()
    {

        GameObject.Find("ApartmentLoop" + LoopCounter.LoopNumber).GetComponentInChildren<FirePlacePlaceHolder>().endPuzzleEvent += openDoorLoop3;



    }

    private void openDoorLoop3()
    {

        // Open animation and sound
        this.GetComponent<Animation>().Play("OpenMainDoor");
        this.GetComponent<AudioSource>().PlayOneShot(openMainDoorSound);

        GameObject.Find("ApartmentLoop" + LoopCounter.LoopNumber).GetComponentInChildren<FirePlacePlaceHolder>().endPuzzleEvent -= openDoorLoop3;

        mainHallDoorShakingScript.canInteract = false;




    }

    private void loop4Init()
    {

        GameObject.Find("ApartmentLoop" + LoopCounter.LoopNumber).GetComponentInChildren<KidsBedroomPlaceHolder>().endPuzzleEvent += openDoorLoop4;

    }

    private void openDoorLoop4()
    {

        // Open animation and sound
        this.GetComponent<Animation>().Play("OpenMainDoor");
        this.GetComponent<AudioSource>().PlayOneShot(openMainDoorSound);

        GameObject.Find("ApartmentLoop" + LoopCounter.LoopNumber).GetComponentInChildren<KidsBedroomPlaceHolder>().endPuzzleEvent -= openDoorLoop4;

        mainHallDoorShakingScript.canInteract = false;


    }


  
}
