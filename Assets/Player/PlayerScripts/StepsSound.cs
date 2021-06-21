using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSample
{
    public float StartTime { get; }
    public float EndTime { get; }

    public AudioSample(float startTime, float endTime)
    {
        this.StartTime = startTime;
        this.EndTime = endTime;
    }
}

public class StepsSound : MonoBehaviour
{
    AudioSource stepsSound;
    List<AudioSample> audioSamples;
    public int CurrentStepIndex;

    // Start is called before the first frame update
    void Start()
    {
        stepsSound = this.GetComponent<AudioSource>();

        audioSamples = new List<AudioSample>();
        AddAudioSamples(audioSamples);

        CurrentStepIndex = 0;

    }

    public void PlayAudioSample()
    {
        stepsSound.time = audioSamples[CurrentStepIndex].StartTime;
        stepsSound.Play();
        stepsSound.SetScheduledEndTime(AudioSettings.dspTime + (audioSamples[CurrentStepIndex].EndTime - audioSamples[CurrentStepIndex].StartTime));

        UpdateCurrentIndex();
    }

    public void UpdateCurrentIndex()
    {
        if (CurrentStepIndex >= audioSamples.Count - 1)
            CurrentStepIndex = 0;
        else
            CurrentStepIndex++;



    }

    private void AddAudioSamples(List<AudioSample> list)
    {
        list.Add(new AudioSample(0, 0.700f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 1.350f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 1.950f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 2.700f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 3.460f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 4.000f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 4.800f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 5.500f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 6.000f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 6.800f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 7.460f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 8.100f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 8.800f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 9.500f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 10.000f));
        list.Add(new AudioSample(list[list.Count - 1].EndTime, 10.700f));
    }
}
