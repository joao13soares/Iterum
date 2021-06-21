using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidsBedroomSoundScript : MonoBehaviour
{
    public int assignedLoop = 4;

    private AudioSource audioSource;
    public AudioClip lullabySound, babyCrySound, babyAndMomSound;

    private KidsBedroomTriggerScript kidsBedroomTriggerScript;
    private KidsBedroomPlaceHolder kidsBedroomPlaceHolderScript;

    // Start is called before the first frame update
    void Start()
    {
        if(LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;
        }
        else
        {
            audioSource = this.GetComponent<AudioSource>();

            audioSource.PlayOneShot(lullabySound, 0.4f);

            kidsBedroomTriggerScript = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<KidsBedroomTriggerScript>();
            kidsBedroomTriggerScript.OnTriggerCollide += playBabyCrySound;

            kidsBedroomPlaceHolderScript = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<KidsBedroomPlaceHolder>();
            kidsBedroomPlaceHolderScript.endPuzzleEvent += playBabyAndMomSound;
        }
    }

    private void playBabyCrySound()
    {
        audioSource.clip = babyCrySound;
        audioSource.loop = true;
        audioSource.Play();
    
        kidsBedroomTriggerScript.OnTriggerCollide -= playBabyCrySound;
    }

    private void playBabyAndMomSound()
    {
        audioSource.loop = false;
        audioSource.Stop();

        audioSource.PlayOneShot(babyAndMomSound, 0.4f);

        kidsBedroomPlaceHolderScript.endPuzzleEvent -= playBabyAndMomSound;
    }
}
