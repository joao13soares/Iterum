using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectInputAnimation : MonoBehaviour
{
    float playerSpeed = 1000f;

    

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        anim.SetFloat("velocityY", Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
        anim.SetFloat("velocityX", Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);





    }
}
