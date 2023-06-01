using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    [SerializeField] int currentSceneIndex;
    bool isSplashScreen;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SplashScreenCheck();
    }

    void Update()
    {
        if (isSplashScreen)
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene(1);
            }
            else { return; }
        }    
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadModeSelect()
    {
        SceneManager.LoadScene(2);
    }

    public void ClassicOffline()
    {

    }

    public void QuitApp()
    {
        Application.Quit();
    }

    void SplashScreenCheck()
    {
        if (currentSceneIndex == 0)
        {
            isSplashScreen = true;
            Invoke("LoadMainMenu", 3f);
        }
        else { isSplashScreen = false; }
    }
}
