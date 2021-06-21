using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilhouetteBehaviour : MonoBehaviour
{
    public int assignedLoop = 1;

    Animation anim;
    AudioSource audioSource;
    public AudioClip disappearSound;

    void Start()
    {
        if(LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;


        }
        else
        {
            GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<Trigger1Script>().onTriggerCollide += DisappearBehaviour;

            audioSource = this.GetComponent<AudioSource>();

            anim = this.GetComponent<Animation>();

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LoopCounter.LoopNumber == assignedLoop)
        {
            if (!anim.isPlaying)
            {

                GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<Trigger1Script>().onTriggerCollide -= DisappearBehaviour;

                Destroy(this.transform.parent.gameObject);

            }
        }
    }

    private void DisappearBehaviour()
    {

        audioSource.Stop();

        // gets high pitch sound
        this.GetComponent<AudioLowPassFilter>().enabled = false;
        audioSource.spatialBlend = 0;

        audioSource.PlayOneShot(disappearSound, 1f);
        
        anim.wrapMode = WrapMode.Once;

        this.GetComponent<Animation>().Play("DisappearAnimation");

        

        
    }
}
