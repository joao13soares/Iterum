using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndGo : MonoBehaviour
{
    Camera playerCamera;
    private GameObject loookingItem, holdingItem;
    private bool isHolding;


    // Start is called before the first frame update
    void Start()
    {
        // Basic init
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera = GetComponentInChildren<Camera>();
        isHolding = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Gets ray from the camera position to the center of screen
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        // Checks if player is looking at any interactable item
        bool isLookingAtInteractablebject = Physics.Raycast(ray, out hit, 4f);

        // if the item he is looking at is interactable(pick or place)
        if (isLookingAtInteractablebject &&
            ( hit.collider.gameObject.CompareTag("Interactable") || hit.collider.gameObject.CompareTag("PlaceHolder")))
        {
            loookingItem = hit.collider.gameObject;
        }

        //// Debugs
        //Debug.Log("Looking at :  " + loookingItem);
        //Debug.Log("Holding : " + holdingItem);


        // Handles Mouse Input
        if (Input.GetMouseButtonDown(0))
        {
            MouseDown();
        }

        // Debug
        //Debug.DrawRay(ray.origin, ray.direction, Color.green, 8, false);

        // Resets lookingItem
        loookingItem = null;
        
    }


    void MouseDown()
    {
        // If player is not holding anything and looking at item he can pick
        if (isHolding == false && loookingItem != null && loookingItem.CompareTag("Interactable"))

            pickUpItem();

        
        // If he already has a picked item and clicks on the place to put it
        else if(isHolding == true && loookingItem!= null && loookingItem.CompareTag("PlaceHolder"))

            placeItem();

    }

    private void pickUpItem()
    {
        // Player is now holding
        isHolding = true;

        // The item he is holding is the one he was looking
        holdingItem = loookingItem;


        // Sets up object to follow player tranform without collisions and physics
        holdingItem.transform.SetParent(this.playerCamera.transform);
        holdingItem.GetComponent<Rigidbody>().isKinematic = true;
        holdingItem.GetComponent<Collider>().enabled = false;

        
        // Places object in front of player
        Vector3 positionRelativeToCamera = new Vector3(-0.46f, -0.27f, 0.7f); 
        holdingItem.transform.localPosition = positionRelativeToCamera;



    }

    private void placeItem()
    {

        Debug.Log("LET IT GO");

        // Is not holding items anymore
        isHolding = false;

        // Sets up collision and physics again
        holdingItem.GetComponent<Rigidbody>().isKinematic = false;
        holdingItem.GetComponent<Collider>().enabled = true;


        // Makes item child of the place he is gonna be in
        holdingItem.transform.SetParent(loookingItem.transform);
        holdingItem.tag = "Untagged";

        // Gets and places the item on the next available position
        if (LoopCounter.LoopNumber == 1 )
            placeItemInKitchen();
        else if (LoopCounter.LoopNumber == 3)
            placeItemInFirePlace();
        else if (LoopCounter.LoopNumber == 4)
            placeItemInKidBedroom();

        // Holding item is now null «
        holdingItem = null;
    }

    private void placeItemInKitchen()
    {
        int positionToBePlaced = loookingItem.GetComponent<KitchenPlaceHolder>().nextPlace++;
        holdingItem.transform.localPosition = loookingItem.GetComponent<KitchenPlaceHolder>().placePositions[positionToBePlaced];
    }

    private void placeItemInFirePlace()
    {
        int positionToBePlaced = loookingItem.GetComponent<FirePlacePlaceHolder>().nextPlace++;
        
        holdingItem.transform.localPosition = loookingItem.GetComponent<FirePlacePlaceHolder>().placePositions[positionToBePlaced];

        loookingItem.GetComponentInChildren<AudioSource>().PlayOneShot(loookingItem.GetComponent<FirePlacePlaceHolder>().placeItemInFirePlaceSound);

    }

    private void placeItemInKidBedroom()
    {
        int positionToBePlaced = loookingItem.GetComponent<KidsBedroomPlaceHolder>().nextPlace++;
        holdingItem.transform.localPosition = loookingItem.GetComponent<KidsBedroomPlaceHolder>().placePositions[positionToBePlaced];
    }

}
