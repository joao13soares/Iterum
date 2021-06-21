using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{

    // LOOP3
    public int assignedLoop = 3;


    Bathroom_Floor_Tracking mirror;
    Vector3 playerPosToClone;
    public GameObject mirrorClone;
    private GameObject player;

    private Vector3 apartmentPosition;



    // Start is called before the first frame update
    void Start()
    {
        if(LoopCounter.LoopNumber != assignedLoop)
        {

            this.enabled = false;
        }
        else
        {
            

            mirror = GameObject.Find("ApartmentLoop" + LoopCounter.LoopNumber).GetComponentInChildren<Bathroom_Floor_Tracking>();
            player = GameObject.Find("Player_1");

            apartmentPosition = GameObject.Find("ApartmentLoop" + LoopCounter.LoopNumber).transform.position;

            mirror.onTriggerEvent += mirrorPlayerPos;
            mirror.onTriggerEvent += mirrorPlayerRotation;

        }

      
    }


    void mirrorPlayerPos()
    {
        Vector3 positionToCopy = mirror.playerPosition;

        mirrorClone.transform.position = (apartmentPosition + this.transform.parent.position) + new Vector3(positionToCopy.x, positionToCopy.y, -positionToCopy.z);
    }



    void mirrorPlayerRotation()
    {
        //float scaleCompensation = GameObject.Find("Mirror").transform.localScale.x;

        Vector3 mirrorPlayerYaw = Vector3.up * 180f;

        mirrorClone.transform.rotation = player.transform.rotation;

        //Vector3 temp = new Vector3(0f, -180f - 2 * player.transform.rotation.y, 0f);
        //mirrorClone.transform.Rotate(temp);


        mirrorClone.transform.Rotate(mirrorPlayerYaw);

        //Quaternion.Euler(new Vector3(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z) * scaleCompensation) ;

    }


}
