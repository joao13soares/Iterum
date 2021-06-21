using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShaking : MonoBehaviour
{
    public bool canInteract;
    private Animation doorShakingAnimation;
    private AudioSource doorShakingSound;

    public delegate void onDoorInteract();
    public onDoorInteract onDoorInteractEvent;

    // Start is called before the first frame update
    void Start()
    {
        canInteract = true;

        doorShakingAnimation = this.GetComponent<Animation>();

        // Lets animation Play in code
        doorShakingAnimation.clip.legacy = true;

        doorShakingSound = this.GetComponent<AudioSource>();

    }

    void OnMouseDown()
    {

        Debug.Log("DETECTPRESS");

        if (canInteract && !doorShakingAnimation.isPlaying && !doorShakingSound.isPlaying)
        {
            Debug.Log("SHAKE");
            if (Movement.distToPlayer(this.transform.position) < 2.5f)
            {
                Debug.Log("animate mf");
                doorShakingAnimation.Play();
                doorShakingSound.Play();

                onDoorInteractEvent?.Invoke();
            }
        }

    }
}
