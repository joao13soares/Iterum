using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLookAtGirl : MonoBehaviour
{
    public delegate void lookAt();
    public lookAt OnLookAtGirlEvent;

    public int assignedLoop = 2;
    private bool lookedAtGirl;

    Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;
        }
        else
        {
            playerCamera = this.GetComponentInChildren<Camera>();
            lookedAtGirl = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(assignedLoop == LoopCounter.LoopNumber)
        {

            // Gets ray from the camera position to the center of screen
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 6f) && hit.collider.gameObject.CompareTag("Silhouette") && !lookedAtGirl)
            {
                hit.collider.enabled = false;

                OnLookAtGirlEvent?.Invoke();
            }

        }
       
    }
}

