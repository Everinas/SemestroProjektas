using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool isToggled;
    Follow cameraMovement;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraMovement = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Follow>();
        player.GetComponent<SimpleCharacterControl>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        //cameraMovement.enabled = true;
        isToggled = true;
        Cursor.visible = false;
    }

    public void Toggle()
    {
        if (isToggled)
        {
            Cursor.visible = true;
            cameraMovement.enabled = false;
            player.GetComponent<SimpleCharacterControl>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
        }
        else
        {
            Cursor.visible = false;
            //cameraMovement.enabled = true;
            player.GetComponent<SimpleCharacterControl>().enabled = true;
            player.GetComponent<Animator>().enabled = true;

        }
        isToggled = !isToggled;

        // Re-center the cursor (should be working on compiled build
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Reset()
    {
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<SimpleCharacterControl>().enabled = true;
        cameraMovement.enabled = true;
        isToggled = true;
        Cursor.visible = false;
    }  
}
