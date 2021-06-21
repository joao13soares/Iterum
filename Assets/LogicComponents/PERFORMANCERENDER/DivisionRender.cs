using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionRender : MonoBehaviour
{
    public int assignedLoop;
    // Start is called before the first frame update
    void Start()
    {
        if (LoopCounter.LoopNumber != assignedLoop)
        {
            this.gameObject.SetActive(false);

        }
    }

    
}
