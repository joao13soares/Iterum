using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidsBedroomPlaceHolder : MonoBehaviour
{
    public Vector3[] placePositions;
    public int nextPlace = 0;
    public int assignedLoop = 4;

    public delegate void kidsBedroomPuzzleEvent();
    public event kidsBedroomPuzzleEvent endPuzzleEvent;

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
            placePositions = new Vector3[4];

            placePositions[0] = new Vector3(0.00524f, -0.01767f, -0.0179f);
            placePositions[1] = new Vector3(0.002f, -0.00738f, -0.0179f);
            placePositions[2] = new Vector3(-0.00722f, 0.00024f, -0.0179f);
            placePositions[3] = new Vector3(0.00179f, 0.00721f, -0.0179f);


        }
    }

    void Update()
    {
        // Puzzle complete
        if (nextPlace == 4)
        {
            // Calls endPuzzle event (open MainDoor)
            endPuzzleEvent?.Invoke();

        }

    }

}
