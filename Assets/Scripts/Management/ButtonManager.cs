using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    EscMenuManager manager;

    public void doRestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public void doExitGame()
    {
        Application.Quit();
    }

    public void doContinue()
    {       
        
    }
}
