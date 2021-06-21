using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop3Blackout : MonoBehaviour
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
            this.GetComponent<Light>().enabled = false;
        }
    }
}
