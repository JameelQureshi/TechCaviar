using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class linkOpeneer : MonoBehaviour 
{
	public void OpenLinks(string URL)
	{
		Application.OpenURL(URL);
	}

	
	
	
    public void OpenLink(int index)
    {
        switch (index)
        {
            case 1:
                Application.OpenURL(SimpleCloudHandler.facebookURL);
                break;
            case 2:
                Application.OpenURL(SimpleCloudHandler.instagramURL);
                break;
            case 3:
                Application.OpenURL(SimpleCloudHandler.buyURL);
                break;
            case 4:
                Application.OpenURL(SimpleCloudHandler.webURL);
                break;
        }

    }

    public void Exit()
    {
        Application.Quit();
    }

}
