using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class AfterImageDetected : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public VideoPlayer MyPlayer;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void Update()
    {
        if (PlayerPrefs.GetInt("found" )== 1)
        {
            
        }
        else if(PlayerPrefs.GetInt("found") == 0)
        {
            
        }
    }
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||newStatus == TrackableBehaviour.Status.TRACKED ||newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            MyPlayer.Play();




        }
        else
        {
            MyPlayer.Pause();

        }
    }
}
