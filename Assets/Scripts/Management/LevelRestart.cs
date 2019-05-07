using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class LevelRestart : MonoBehaviour
{
    public static void doRestartCurrentLevel()
    {
        SaveGame.Save<int>("Score", 0);
        SaveGame.Save<int>("Health", 5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene     
    }
}
