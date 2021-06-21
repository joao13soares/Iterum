using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomDoorBehaviour : MonoBehaviour
{
    public int assignedLoop = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;
        }
        else
        {
            this.transform.localRotation = Quaternion.Euler(new Vector3(0f, -120f, 0f));
        }
    }
}
