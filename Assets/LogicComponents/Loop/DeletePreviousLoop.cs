using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePreviousLoop : MonoBehaviour
{
    GameObject player;

    void OnTriggerEnter(Collider playerCapsule)
    {
        int previousLoopNumber = LoopCounter.LoopNumber - 1;
        Destroy(GameObject.Find("ApartmentLoop" + previousLoopNumber));

        player = playerCapsule.gameObject.transform.parent.gameObject;

        player.GetComponent<Animation>().Stop();

        player.transform.SetParent(null);
        Destroy(GameObject.Find("Temp"));

        player.GetComponent<CameraMovement>().resetYawPitch();
    }

    private void OnTriggerStay(Collider other)
    {
        if (GameObject.Find("StartLevelDoor").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Closed"))
        {
            player.GetComponentInChildren<Movement>().playerCurrentState = Movement.playerState.IDLE;

            Destroy(this.gameObject);
        }
    }
}
