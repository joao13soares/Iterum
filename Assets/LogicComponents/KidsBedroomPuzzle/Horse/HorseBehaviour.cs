using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseBehaviour : MonoBehaviour
{
    public int assignedLoop = 4;

    private KidsBedroomPlaceHolder scriptForAnimation;

    // Start is called before the first frame update
    void Start()
    {

        scriptForAnimation = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<KidsBedroomPlaceHolder>();

        scriptForAnimation.endPuzzleEvent += playHorseAnimation;

    }



  private void playHorseAnimation()
    {

        this.GetComponentInChildren<Animation>().Play();
        scriptForAnimation.endPuzzleEvent -= playHorseAnimation;

    }
}
