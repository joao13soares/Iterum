using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class TVScreenBehaviour : MonoBehaviour
{
    // O VERDADEIRO É 3
    public int assignedLoop = 1;

    private VideoPlayer TVPlayer;
    public VideoClip staticClip, newsClip;

    private FirePlaceBehaviour turnOnTVscriptEvent;
    // Start is called before the first frame update

    public delegate void TVBehaviour();
    public event TVBehaviour OnTurnOffTV;

    void Start()
    {
        if (LoopCounter.LoopNumber != assignedLoop)
        {
            this.enabled = false;

        }
        else
        {
            TVPlayer = this.GetComponent<VideoPlayer>();
            TVPlayer.clip = staticClip;
            TVPlayer.Play();

            turnOnTVscriptEvent = GameObject.Find("ApartmentLoop" + assignedLoop).GetComponentInChildren<FirePlaceBehaviour>();
            turnOnTVscriptEvent.OnTurnOnFireplace += turnOnTV;


           
        }

    }


    private void turnOnTV()
    {

        TVPlayer.Stop();
        TVPlayer.isLooping = false;
        TVPlayer.clip = newsClip;
        TVPlayer.Play();

        turnOnTVscriptEvent.OnTurnOnFireplace -= turnOnTV;

        TVPlayer.loopPointReached += TurnOffTV;
        
    }

    private void TurnOffTV(VideoPlayer TVPlayer)
    {
        this.GetComponentInChildren<Light>().enabled = false;
        this.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");

        OnTurnOffTV?.Invoke();

        TVPlayer.loopPointReached -= TurnOffTV;



    }




}
