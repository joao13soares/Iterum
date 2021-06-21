using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("NextLevelDoorFrame").name = "StartLevelDoorFrame";

        GameObject startLevelDoor = GameObject.Find("NextLevelDoor");
        startLevelDoor.name = "StartLevelDoor";

        GameObject startLevelDoorSystem = startLevelDoor.transform.parent.gameObject;
        startLevelDoorSystem.name = "StartLevelDoorSystem";

        startLevelDoor.GetComponent<Animator>().SetBool("open", false);

        Destroy(this.gameObject);
    }
}
