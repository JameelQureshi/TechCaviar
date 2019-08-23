using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    public GameObject Splash;
    public GameObject mainMenu;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(false);
        Splash.SetActive(true);
        Invoke("TurnOnMenu", delay);
    }
    void TurnOnMenu()
    {
        mainMenu.SetActive(true);
        Splash.SetActive(false);
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void OpenURL(string URL)
    {
        Application.OpenURL(URL);
    }


}
