using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToMain : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Time());
    }

    IEnumerator Time()
    { 
       yield return new WaitForSeconds(2f);
       StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        if (PlayerPrefs.GetInt("UserlogedIn") == 0)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LoginSignup");
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
        else
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("AR");
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }

}
