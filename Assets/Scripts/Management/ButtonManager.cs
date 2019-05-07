using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static void doRestartCurrentLevel()
    {
        LevelRestart.doRestartCurrentLevel();
    }

    public static void doExitGame()
    {
        Application.Quit();
    }

    public static void doContinue()
    {       
        
    }
}
