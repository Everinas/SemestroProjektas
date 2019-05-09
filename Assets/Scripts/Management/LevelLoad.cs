using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public CameraFollow cameraMovement;
    void OnTriggerStay()
    {
        if (Input.GetButtonDown("E"))
        {
            if (NPC_Dialogue.levelchange == true)
            {
                SceneManager.LoadScene("HomeVillage");
                cameraMovement = GameObject.FindGameObjectWithTag("CameraFolder").GetComponent<CameraFollow>();
                cameraMovement.enabled = false;
                cameraMovement.enabled = true;
            }
        }
    }
    
}
