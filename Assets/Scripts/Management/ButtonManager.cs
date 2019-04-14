using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    EscMenuManager manager;

    public void doRestartCurrentLevel()
    {

        SaveGame.Save<int>("Score", 0);
        SaveGame.Save<int>("Health", 5);
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
