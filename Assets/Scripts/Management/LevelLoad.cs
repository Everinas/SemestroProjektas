using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    

    
    void OnTriggerStay()
    {
        if (Input.GetButtonDown("E"))
        {
            if (NPC_Dialogue.levelchange == true)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
    
}
