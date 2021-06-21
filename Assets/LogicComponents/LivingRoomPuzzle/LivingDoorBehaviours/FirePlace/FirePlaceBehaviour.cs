using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceBehaviour : MonoBehaviour
{
    public int assignedLoop = 3;

    public delegate void interactBehaviour();
    public event interactBehaviour OnTurnOnFireplace;
    private bool isLightUp;

    // Start is called before the first frame update
    void Start()
    {
        if(LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;

        }
        else
        {

            isLightUp = false;
            
        }

    }

    void OnMouseDown()
    {
        if (!isLightUp && Movement.distToPlayer(this.transform.position)< 2f)
        {
            // Turns on Particle and Light
            this.GetComponentInChildren<ParticleSystem>().Play();
            this.GetComponentInChildren<Light>().enabled = true;

            // Turns on FirePlaceSound
            this.GetComponentInChildren<AudioSource>().Play();

            // Invokes event for tv news
            OnTurnOnFireplace?.Invoke();

            // Prevents player from turning it off
            isLightUp = true;
        }

       
    }
}
