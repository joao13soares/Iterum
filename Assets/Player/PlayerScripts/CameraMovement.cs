using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Essential Components----------------------------------------

    [SerializeField] private GameObject playerCamera;


    // Camera variables--------------------------------------------

    private Camera playerView;
    private float defaultFOV;

    private float yawPlayer, pitchPlayer;

    private Movement.playerState playerCurrentState;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Gets acess to camera GameObject
        playerCamera = GameObject.Find("Main Camera");

        // Gets player Camera component and default field of view
        playerView = playerCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        playerCurrentState = this.GetComponentInChildren<Movement>().playerCurrentState;

        cameraManager();
    }

    private void cameraManager()
    {
        if (playerCurrentState != Movement.playerState.ANGLEADJUSTING)
        {
            // Gets player mouse movement
            float tempPitchPlayer = pitchPlayer -  Input.GetAxis("Mouse Y");

            pitchPlayer = Mathf.Clamp(tempPitchPlayer, -55f, 55f);

            yawPlayer += Input.GetAxis("Mouse X");

            // tranforms entire player
            this.transform.eulerAngles = new Vector3(0f, yawPlayer, 0f);


            

            this.playerCamera.transform.eulerAngles = new Vector3(pitchPlayer, this.transform.eulerAngles.y, this.playerCamera.transform.eulerAngles.z);
        }
        else
        {
            GameObject endLoopTrigger = GameObject.Find("EndLoopTrigger");

            float angleY, angleX;

            if (checkYawPitch(endLoopTrigger.transform, out angleY, out angleX))
            {
                if(adjustYawPitch(angleY, angleX))
                {
                    this.transform.rotation = endLoopTrigger.transform.rotation;
                    this.playerCamera.transform.localRotation = Quaternion.identity;
                }
            }
        }
    }

    public bool checkYawPitch(Transform referenceTransform, out float angleY, out float angleX)
    {
        angleY = Vector3.SignedAngle(this.transform.forward, referenceTransform.forward, Vector3.up);

        Vector3 pitchCamProjVector = new Vector3(referenceTransform.forward.x, playerCamera.transform.forward.y, 0);

        angleX = Vector3.SignedAngle(pitchCamProjVector, referenceTransform.forward, Vector3.right) * 2f;

        return (Mathf.Abs(angleY) <= 45.0f && Mathf.Abs(angleX) <= 45.0f);
    }

    private bool adjustYawPitch(float angleY, float angleX)
    {
        bool isAdjusted;

        if (Mathf.Abs(angleY) >= 1f || Mathf.Abs(angleX) >= 1f)
        {
            float deltaTime = Time.deltaTime;

            if (Mathf.Abs(angleY) >= 1f)
                this.transform.Rotate(new Vector3(0, Mathf.Sign(angleY) * 20 * deltaTime, 0));

            if (Mathf.Abs(angleX) >= 1f)
                playerCamera.transform.Rotate(new Vector3(-Mathf.Sign(angleX) * 20 * deltaTime, 0, 0));

            isAdjusted = false;
        }
        else
        {
            isAdjusted = true;
        }

        return isAdjusted;
    }

    public void resetYawPitch()
    {
        yawPlayer = -90.0f;
        pitchPlayer = 0f;
    }

    public bool checkAngle(float yawTrigger, float pitchTrigger, out float yawDiff, out float pitchDiff)
    {
        // ORIENTATION PITCH + down // ORIENTATION YAW + right
        if (pitchTrigger > 180f)
            pitchTrigger -= 360f;
        if (yawTrigger > 180f)
            yawTrigger -= 360f;

        if (yawTrigger < yawPlayer)
            yawDiff = yawPlayer - yawTrigger;
        else
            yawDiff = yawTrigger - yawPlayer;

        if (pitchTrigger < pitchPlayer)
            pitchDiff = pitchTrigger - pitchPlayer;
        else
            pitchDiff = pitchPlayer - pitchTrigger;

        //Debug.Log("yaw: " + yawDiff + " = " + yawTrigger + " - " + yawPlayer);
        //Debug.Log("pitch: " + pitchDiff + " = " + pitchTrigger + " - " + pitchPlayer);

        return (Mathf.Abs(yawPlayer) <= Mathf.Abs(yawDiff + yawTrigger) && Mathf.Abs(pitchPlayer) <= Mathf.Abs(pitchDiff + pitchTrigger));
    }

    public void adjustAngle(float yawDiff, float pitchDiff)
    {
        if (Mathf.Abs(yawDiff) >= 1f || Mathf.Abs(pitchDiff) >= 1f)
        {
            float deltaTime = Time.deltaTime;

            if (Mathf.Abs(yawDiff) >= 1f)
            {
                float newYawPlayer = Mathf.Sign(yawDiff) * deltaTime;
                this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, newYawPlayer, this.transform.eulerAngles.z);
            }

            if (Mathf.Abs(pitchDiff) >= 1f)
            {
                float newPitchPlayer = Mathf.Sign(pitchDiff) * deltaTime;
                this.playerCamera.transform.eulerAngles = new Vector3(newPitchPlayer, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
            }
        }
    }
}
