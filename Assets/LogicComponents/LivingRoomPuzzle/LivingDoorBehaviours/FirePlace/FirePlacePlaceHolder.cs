using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlacePlaceHolder : MonoBehaviour
{

    public Vector3[] placePositions;
    public int nextPlace = 0;
    public int assignedLoop = 3;

    public delegate void livingRoomPuzzleEvent();
    public event livingRoomPuzzleEvent firstItemPlacedEvent, endPuzzleEvent;

    public AudioClip placeItemInFirePlaceSound;

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
            placePositions = new Vector3[2];

            placePositions[0] = new Vector3(-0.116f, 0.079f, 0.117f);
            placePositions[1] = new Vector3(0.1088f, 0.079f, 0.117f);


        }
    }

    void Update()
    {
        // Puzzle beggining
        if (nextPlace == 1)
        {
            // Calls startPuzzle event(start BathroomBehaviour)
            firstItemPlacedEvent?.Invoke();

        }

        // Puzzle complete
        if (nextPlace == 2)
        {
            // Calls endPuzzle event (open MainDoor)
            endPuzzleEvent?.Invoke();

        }

    }

    // Function for playing its sound when player places pills in the FirePlace
    private void playFirePlacePlaceItemSound()
    {
        this.GetComponentInChildren<AudioSource>().PlayOneShot(placeItemInFirePlaceSound, 1f);

    }


}
