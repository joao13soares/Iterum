using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBopping : MonoBehaviour
{
    // Essential Components----------------------------------------

    [SerializeField] private GameObject playerCamera;

    private Movement.playerState playerCurrentState;
    [SerializeField] private float smoothTurn;
    private float headDirection, headTrack;

    // Start is called before the first frame update
    void Start()
    {
        // Gets acess to camera GameObject
        playerCamera = GameObject.Find("Main Camera");

        headDirection = 1;

        
        smoothTurn = 0.01f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerCurrentState = this.GetComponentInChildren<Movement>().playerCurrentState;
        stateManager();

        headTurn();
    }

    // Manages head balance (head like sensation)
    private void headTurn()
    {
        // Head limits
        float leftLimitAngle = -1f;
        float rightLimitAngle = 1f;


        // Checks current direction of head turning
        if (headTrack < leftLimitAngle)
        {
            headDirection = 1;
            PlayStepSound();
        }
        else if (headTrack > rightLimitAngle)
        {
            headDirection = -1;
            PlayStepSound();
        }

        // Changes headtrack according to turnSpeed and current direction
        headTrack += headDirection * smoothTurn;

        playerCamera.transform.eulerAngles = new Vector3(playerCamera.transform.eulerAngles.x, playerCamera.transform.eulerAngles.y, headTrack);
    }

    private void PlayStepSound()
    {
        if (playerCurrentState == Movement.playerState.WALKING)
            this.GetComponent<StepsSound>().PlayAudioSample();
    }


    // Changes speed and smooth Turn according to player state
    private void stateManager()
    {
        switch (playerCurrentState)
        {

            case Movement.playerState.IDLE:
                smoothTurn = 0.01f;
                break;

            case Movement.playerState.WALKING:
                smoothTurn = 0.05f;
                break;

            case Movement.playerState.ANGLEADJUSTING:
                smoothTurn = 0.00f;
                break;

            default:
                smoothTurn = 1f;
                break;



        }

    }
}
