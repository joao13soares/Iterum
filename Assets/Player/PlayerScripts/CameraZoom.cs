using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] Camera playerView;

    private float defaultFOV;


    // Start is called before the first frame update
    void Start()
    {
        playerView = this.GetComponentInChildren<Camera>();
        defaultFOV = playerView.fieldOfView;

    }

    void Update()
    {
        cameraZoom();

    }

    private void cameraZoom()
    {
        float maxZoom = 35f;
        float currentZoom = playerView.fieldOfView;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (currentZoom > maxZoom)
                playerView.fieldOfView -= playerView.fieldOfView * Time.deltaTime;

        }
        else
        {
            if (currentZoom < defaultFOV)
                playerView.fieldOfView += playerView.fieldOfView * Time.deltaTime;


        }

    }
}
