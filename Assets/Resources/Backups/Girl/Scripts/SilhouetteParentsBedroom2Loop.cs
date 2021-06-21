using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilhouetteParentsBedroom2Loop : MonoBehaviour
{
    public int assignedLoop = 2;

    public AudioClip parentsBedroomJumpscareSound;

    private DetectLookAtGirl bedroomJumpscareEvent;


    // Start is called before the first frame update
    void Start()
    {
        if (LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;
        }
        else
        {
            // Subscribes for trigger1 for disappearing 
            bedroomJumpscareEvent = GameObject.Find("Player_1").GetComponentInChildren<DetectLookAtGirl>();
            bedroomJumpscareEvent.OnLookAtGirlEvent += jumpscareParentsBedroom;
        }


    }



    private void jumpscareParentsBedroom()
    {
        // Plays jumpscare sound and destroys silhouette(unsubscribes from event)
        AudioSource.PlayClipAtPoint(parentsBedroomJumpscareSound, this.transform.position);

        bedroomJumpscareEvent.OnLookAtGirlEvent -= jumpscareParentsBedroom;

        Destroy(this.transform.parent.gameObject);

    }
}
