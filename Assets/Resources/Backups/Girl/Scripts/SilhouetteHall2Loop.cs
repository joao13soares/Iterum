using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilhouetteHall2Loop : MonoBehaviour
{
    public int assignedLoop = 2;

    private Trigger1Script SilhouetteHall2LoopTrigger;
    public AudioClip jumpScareHallSound;

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
            SilhouetteHall2LoopTrigger = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<Trigger1Script>();
            SilhouetteHall2LoopTrigger.onTriggerCollide += disappearMainHall;
        }
    }

    private void disappearMainHall()
    {
        // move girl to void
        AudioSource.PlayClipAtPoint(jumpScareHallSound, this.transform.position);
        SilhouetteHall2LoopTrigger.onTriggerCollide -= disappearMainHall;

        this.transform.parent.position = Vector3.zero;

        this.GetComponent<SilhouetteParentsBedroom2Loop>().enabled = true;
        GameObject.Find("Player_1").GetComponent<DetectLookAtGirl>().enabled = true;

    }

    
  

}
