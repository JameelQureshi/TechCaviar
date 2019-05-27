using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SharingPoints : MonoBehaviour
{
	
	private Texture2D texture;
	public Button MYShareBtn;
	
   
	
	public void ShareHashTag()
    {

    }
	
	public void ShareBtn()
	{
		MYShareBtn.interactable = false;
		StartCoroutine(waitfor2sec());
	}

	IEnumerator waitfor2sec()
	{
		yield return new WaitForSeconds(0.3f);
		MYShareBtn.interactable = true;
		ShareHashTag();
		StartCoroutine(waitfor1point5sec());
	}
	IEnumerator waitfor1point5sec()
	{
		yield return new WaitForSeconds(1.3f);
		Pointsrewarded();
	}
	
	void Pointsrewarded () 
	{
		PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + PlayerPrefs.GetInt("PointsToGive"));
		
    }
	
}
