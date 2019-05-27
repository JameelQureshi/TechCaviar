using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetPlayVideo : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public YoutubePlayer MyPlayer;
    public GameObject facebook;
    public GameObject instagram;
    public GameObject buy;
    public GameObject web;
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
            MyPlayer.PlayButton();

            if (SimpleCloudHandler.haveFacebook)
            {
                facebook.SetActive(true);
            }
            if (SimpleCloudHandler.haveInstagram)
            {
                instagram.SetActive(true);
            }
            if (SimpleCloudHandler.haveBuy)
            {
                buy.SetActive(true);
            }
            if (SimpleCloudHandler.haveWeb)
            {
                web.SetActive(true);
            }




        }
        else
        {
            MyPlayer.Pause();

            facebook.SetActive(false);
            instagram.SetActive(false);
            buy.SetActive(false);
            web.SetActive(false);
        }
    }
}
