using System;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System.IO;

/// <summary>
/// This MonoBehaviour implements the Cloud Reco Event handling for this sample.
/// It registers itself at the CloudRecoBehaviour and is notified of new search results.
/// </summary>
public class SimpleCloudHandler : MonoBehaviour, ICloudRecoEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES

    // CloudRecoBehaviour reference to avoid lookups
    private CloudRecoBehaviour mCloudRecoBehaviour;
    // ImageTracker reference to avoid lookups
    private ObjectTracker mImageTracker;

    private bool mIsScanning = false;

    private string mTargetMetadata = "";

    #endregion // PRIVATE_MEMBER_VARIABLES

    private string[] LinksthroughMatadata;
    private Texture2D texture;
    public YoutubePlayer MyPlayer;

   
    string filePath;

    public static bool haveFacebook=false;
    public static bool haveInstagram=false;
    public static bool haveBuy=false;
    public static bool haveWeb=false;

    public static string facebookURL;
    public static string instagramURL;
    public static string buyURL;
    public static string webURL;


    #region EXPOSED_PUBLIC_VARIABLES

    /// <summary>
    /// can be set in the Unity inspector to reference a ImageTargetBehaviour that is used for augmentations of new cloud reco results.
    /// </summary>
    public ImageTargetBehaviour ImageTargetTemplate;


    #endregion

    #region UNTIY_MONOBEHAVIOUR_METHODS

    /// <summary>
    /// register for events at the CloudRecoBehaviour
    /// </summary>
    void Start()
    {
        // register this event handler at the cloud reco behaviour
        CloudRecoBehaviour cloudRecoBehaviour = GetComponent<CloudRecoBehaviour>();
        if (cloudRecoBehaviour)
        {
            cloudRecoBehaviour.RegisterEventHandler(this);
        }

        // remember cloudRecoBehaviour for later
        mCloudRecoBehaviour = cloudRecoBehaviour;


    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS


    #region ICloudRecoEventHandler_IMPLEMENTATION

    /// <summary>
    /// called when TargetFinder has been initialized successfully
    /// </summary>

    public void OnInitialized(TargetFinder targetFinder)
    {
        mImageTracker = (ObjectTracker)TrackerManager.Instance.GetTracker<ObjectTracker>();
    }
    /// <summary>
    /// visualize initialization errors
    /// </summary>
    public void OnInitError(TargetFinder.InitState initError)
    {
    }

    /// <summary>
    /// visualize update errors
    /// </summary>
    public void OnUpdateError(TargetFinder.UpdateState updateError)
    {
    }

    /// <summary>
    /// when we start scanning, unregister Trackable from the ImageTargetTemplate, then delete all trackables
    /// </summary>
    public void OnStateChanged(bool scanning)
    {
        mIsScanning = scanning;
        if (scanning)
        {
            // clear all known trackables
            ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
            tracker.TargetFinder.ClearTrackables(false);
        }
    }

    /// <summary>
    /// Handles new search results
    /// </summary>
    /// <param name="targetSearchResult"></param>
    public void OnNewSearchResult(TargetFinder.TargetSearchResult targetSearchResult)
    {
        // duplicate the referenced image target
        GameObject newImageTarget = Instantiate(ImageTargetTemplate.gameObject) as GameObject;

        GameObject augmentation = null;


        TargetFinder.CloudRecoSearchResult cloudResult = (TargetFinder.CloudRecoSearchResult)targetSearchResult;
        string MetaDataRecieved = cloudResult.MetaData;


        if (augmentation != null)
            augmentation.transform.parent = newImageTarget.transform;

        // enable the new result with the same ImageTargetBehaviour:
        ImageTargetBehaviour imageTargetBehaviour = (ImageTargetBehaviour)mImageTracker.TargetFinder.EnableTracking(targetSearchResult, newImageTarget);


        //Debug.Log("Metadata value is " + MetaDataRecieved);
        mTargetMetadata = MetaDataRecieved;

        ////////////////////////////////////////////////
        if (MetaDataRecieved != null)
        {
            //byte[] decodedBytes = Convert.FromBase64String(MetaDataRecieved);
            //string decodedText = Encoding.UTF8.GetString(decodedBytes);

            print("Meta Data" + MetaDataRecieved);
            LinksthroughMatadata = MetaDataRecieved.Split(',');

            if (LinksthroughMatadata[0] != null)
            {
                MyPlayer.LoadYoutubeVideo(LinksthroughMatadata[0]);
                MyPlayer.objectsToRenderTheVideoImage[0] = imageTargetBehaviour.transform.GetChild(0).gameObject;
            }
            
            if (LinksthroughMatadata[1] != null)
            {
                if (LinksthroughMatadata[1].Length > 4) {
                    facebookURL = LinksthroughMatadata[1];
                    haveFacebook = true;
                }

            }
            else
            {
                haveFacebook = false;
            }

            if (LinksthroughMatadata[2] != null)
            {
                if (LinksthroughMatadata[2].Length > 4)
                {
                    instagramURL = LinksthroughMatadata[2];
                    haveInstagram = true;
                }
             }
            else
            {
                haveInstagram = false;
            }

            if (LinksthroughMatadata[3] != null)
            {
                if (LinksthroughMatadata[3].Length > 4)
                {
                    buyURL = LinksthroughMatadata[3];
                    haveBuy = true;
                }
            }
            else
            {
                haveBuy = false;
            }
            if (LinksthroughMatadata[4] != null)
            {
                if (LinksthroughMatadata[4].Length > 4)
                {
                    webURL = LinksthroughMatadata[4];
                    haveWeb = true;
                }
            }
            else
            {
                haveWeb = false;
            }

        }

        ////////////////////////////////////////////////
        if (!mIsScanning)
        {
            // stop the target finder
            mCloudRecoBehaviour.CloudRecoEnabled = true;
        }
    }

    public void OpenVideoUrl()
    {
        if (LinksthroughMatadata[1] != null)
        {
            MyPlayer.PlayPause();
            StartCoroutine(LinkRecoIncrementer(PlayerPrefs.GetString("projectid")));
            Application.OpenURL(LinksthroughMatadata[1]);
        }
    }
    IEnumerator RecoIncrementer (string projectid) 
    {
        print("Adding reco from the web");
        WWW www = new WWW("http://18.195.233.165/project_apis/" + projectid + "/image_increment?token=PzJpRTo2d9dJ0D7Xv6bcGMPUj24zAgRa");
        yield return www;
    }
    IEnumerator LinkRecoIncrementer (string projectid) 
    {
        print("Adding link reco from the web");
        WWW www = new WWW("http://18.195.233.165/project_apis/" + projectid + "/link_hit_increment?token=PzJpRTo2d9dJ0D7Xv6bcGMPUj24zAgRa");
        yield return www;
    }
    IEnumerator DownloadImage (string projectid) 
    {
        print("Downloading from the web");
        WWW www = new WWW("http://18.195.233.165/project_apis/" + projectid + "/get_target_image?token=PzJpRTo2d9dJ0D7Xv6bcGMPUj24zAgRa");
        print("http://18.195.233.165/project_apis/" + projectid + "/get_target_image?token=PzJpRTo2d9dJ0D7Xv6bcGMPUj24zAgRa");
        yield return www;
        texture = www.texture;
        filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, texture.EncodeToPNG());
        PlayerPrefs.SetString("Imagepath", filePath);
        print(PlayerPrefs.GetString("Imagepath"));
    }
    
    #endregion // ICloudRecoEventHandler_IMPLEMENTATION


}