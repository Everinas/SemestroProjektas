using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleteManager : MonoBehaviour
{
    public GameObject player;
    public GameObject completeMenu;
    public CameraFollow cameraMovement;
    public bool win;

    private void Start()
    {
        win = false;
        // Hide the cursor while playing
        completeMenu.SetActive(false);
        Cursor.visible = false;
        cameraMovement = GameObject.FindGameObjectWithTag("CameraFolder").GetComponent<CameraFollow>();
    }

    private void Update()
    {
        // Condition on win
        if (win)
        {
            // Turn the cursor back on when complete
            cameraMovement.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Trigger the LevelComplete view

            completeMenu.SetActive(true);

            // Maybe define our own character controller?
            player.GetComponent<SimpleCharacterControl>().enabled = false;
        }
    }

    public void SetWin()
    {
        win = true;
    }
}
