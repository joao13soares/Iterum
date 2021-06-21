using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterBehaviour : MonoBehaviour
{
    public int assignedLoop = 2;
    
    public bool isPickedUp = false;

    ParticleSystem flame;

    Animator lighterAnimator;

    public delegate void onPickUpEvent();
    public event onPickUpEvent onPickUp;
    public event onPickUpEvent onTurnOn;

    DetectLookAtGirl blowOutEvent;

    // Start is called before the first frame update
    void Start()
    {

        if(assignedLoop != LoopCounter.LoopNumber)
        {
            this.enabled = false;

        }

        else
        {
            flame = this.GetComponentInChildren<ParticleSystem>();
            this.GetComponentInChildren<Light>().enabled = false;

            lighterAnimator = this.GetComponentInChildren<Animator>();

            blowOutEvent = GameObject.Find("Player_1").GetComponent<DetectLookAtGirl>();

            blowOutEvent.OnLookAtGirlEvent += blowOutLighter;

            Debug.Log("ISQUEIRO LOOP " + LoopCounter.LoopNumber +"   " +  this.transform.position);

        }

    }

    // Update is called once per frame WITH ANIMATOR
    void Update()
    {
        if ((isPickedUp && Input.GetKeyDown(KeyCode.F)))
        {
            lighterAnimator.SetTrigger("keyWasClicked");
        }

        // play Lighter turnOn sound
        if (lighterAnimator.GetCurrentAnimatorStateInfo(0).IsName("OpeningAnimation"))
            this.GetComponent<AudioSource>().Play();

        if (!flame.isPlaying && lighterAnimator.GetCurrentAnimatorStateInfo(0).IsName("FlameCanAnimate"))
        {
            flame.Play();
            this.GetComponentInChildren<Light>().enabled = true;

            lighterAnimator.SetBool("flaming", true);

            // turns the boolean canInteract of the ParentsBedroomDoor to true
            onTurnOn?.Invoke();
        }
        else if (flame.isPlaying && lighterAnimator.GetCurrentAnimatorStateInfo(0).IsName("CheckingFlame"))
        {
            flame.Stop();
            this.GetComponentInChildren<Light>().enabled = false;

            lighterAnimator.SetBool("flaming", false);
        }
    }

    //void Update()
    //{
    //    if ((isPickedUp && Input.GetKeyDown(KeyCode.F)))
    //   {
    //        AnimationClip clip;
    //        AnimationEvent[] events =  clip.events;

    //        events[0]. += blowOutLighter;
    //        if (!flame.isPlaying)
    //        {
    //            flame.Play();
    //            this.GetComponentInChildren<Light>().enabled = true;
                
    //            onTurnOn?.Invoke();
    //        }
    //        else if (flame.isPlaying && lighterAnimator.GetCurrentAnimatorStateInfo(0).IsName("CheckingFlame"))
    //        {
    //            flame.Stop();
    //            this.GetComponentInChildren<Light>().enabled = false;
                
    //        }
    //    }

    //}

    void OnMouseDown()
    {
        if (Movement.distToPlayer(this.transform.position) < 2f)
        {
            isPickedUp = true;

            // turns off the ParentsBedroom Lights
            onPickUp?.Invoke();

            //this.transform.rotation = Quaternion.Euler(new Vector3(0f, 25f, -225));
            this.transform.SetParent(GameObject.Find("Player_1").GetComponentInChildren<Camera>().transform);
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Collider>().enabled = false;

            this.transform.localPosition = new Vector3(0.4f, -0.5f, 0.8f);
            this.transform.localRotation = Quaternion.Euler(new Vector3(-80f, 180f, 80f));
        }
    }

    private void blowOutLighter()
    {
        lighterAnimator.SetTrigger("keyWasClicked");

        flame.Stop();
        this.GetComponentInChildren<Light>().enabled = false;

        lighterAnimator.SetBool("flaming", false);

        blowOutEvent.OnLookAtGirlEvent -= blowOutLighter;

    }

   void OnOpenAnimationEnd()
    {


    }

}
