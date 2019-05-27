using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollControl : MonoBehaviour {

	void OnEnable()
    {
        GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
    }
}
