using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool isToggled;
    CameraFollow cameraMovement;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraMovement = GameObject.FindGameObjectWithTag("CameraFolder").GetComponent<CameraFollow>();
        player.GetComponent<SimpleCharacterControl>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        isToggled = true;
        Cursor.visible = false;
    }

    public void Toggle()
    {
        if (!isToggled)
        {
            Cursor.visible = true;
            //cameraMovement.enabled = false;
            player.GetComponent<SimpleCharacterControl>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.visible = false;
            //cameraMovement.enabled = true;
            player.GetComponent<SimpleCharacterControl>().enabled = true;
            player.GetComponent<Animator>().enabled = true;
            Time.timeScale = 1;
        }
        isToggled = !isToggled;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Reset()
    {
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<SimpleCharacterControl>().enabled = true;
        //cameraMovement.enabled = true;
        isToggled = false;
        Cursor.visible = false;
    }  
}
