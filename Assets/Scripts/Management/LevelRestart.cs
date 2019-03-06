using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRestart : MonoBehaviour
{
    void doRestartCurrentLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
