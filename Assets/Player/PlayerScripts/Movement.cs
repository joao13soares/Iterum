using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Player State 
    public enum playerState
    {
        IDLE = 0,
        WALKING = 1,
        ANGLEADJUSTING = 2,

    };

    public playerState playerCurrentState;

    // Essential Components----------------------------------------

    [SerializeField] private Rigidbody playerRb;
    // ------------------------------------------------------------


    // Movement variables------------------------------------------

    [SerializeField] private float playerSpeed;
    

    // Start is called before the first frame update
    void Start()
    {

        // Gets acess to player rigidbody
        this.playerRb = this.GetComponent<Rigidbody>();

        // Base Speed
        this.playerSpeed = 2f;

    }

    // Update is called once per frame
    void Update()
    {
        getInputMovement();
    }

    private void getInputMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 currentPos = this.transform.position;

        Vector3 movDirection = Vector3.zero;

        if (playerCurrentState != playerState.ANGLEADJUSTING)
        {
            if (x != 0 || z != 0)
            {
                playerCurrentState = playerState.WALKING;
                movDirection = new Vector3(x, 0f, z);
            }
            else
                playerCurrentState = playerState.IDLE;

            playerRb.transform.Translate(movDirection * playerSpeed * Time.deltaTime);


        }
    }

    static public float distToPlayer(Vector3 objectPos)
    {
        return (GameObject.Find("Player_1").transform.position - objectPos).magnitude;
    }

   



}
