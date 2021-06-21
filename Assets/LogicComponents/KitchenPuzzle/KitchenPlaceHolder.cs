using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPlaceHolder : MonoBehaviour
{
    public Vector3[] placePositions;
    public int nextPlace = 0;
    public int assignedLoop = 1;

    public delegate void kitchenPuzzleEvent();
    public event kitchenPuzzleEvent startPuzzleEvent, endPuzzleEvent;

    private Trigger2Script triggerToPlaySound;



    bool closeKitchenDoor = false;


    // Start is called before the first frame update
    void Start()
    {
        // If not beeing used deactivates script for performance
        if (LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;

        }


        else
        {

            // Makes predefined array of postions for placing objects
            placePositions = new Vector3[4];

            placePositions[0] = new Vector3(-0.253f, 2.542f, 0.3f);
            placePositions[1] = new Vector3(-0.743f, 3.25f, 0.3f);
            placePositions[2] = new Vector3(-2.099f, 3.25f, 0.3f);
            placePositions[3] = new Vector3(-2.573f, 3.25f, 0.3f);


            // Subscribes to trigger2 for sound play
            triggerToPlaySound = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<Trigger2Script>();
            triggerToPlaySound.onTriggerCollide += playKitchenSound;


        }




    }

    void Update()
    {
        // Puzzle beggining
        if (nextPlace == 1 && closeKitchenDoor == false)
        {
            closeKitchenDoor = true;

            // Calls startPuzzle event(close kitchen door)
            startPuzzleEvent?.Invoke();


        }

        // Puzzle complete
        if (nextPlace == 4 && closeKitchenDoor == true)
        {
            closeKitchenDoor = false;

            // Calls endPuzzle event (open kitchen and final door)
            endPuzzleEvent?.Invoke();


        }


    }

    // Function sent to Trigger2 for playing its sound when player passes
    private void playKitchenSound()
    {

        triggerToPlaySound.onTriggerCollide -= playKitchenSound;
        this.GetComponent<AudioSource>().Play();

    }

}
