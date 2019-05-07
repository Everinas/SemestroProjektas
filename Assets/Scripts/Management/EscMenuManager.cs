using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenuManager : MonoBehaviour
{
    bool isPaused;
    public EscMenuManager menu;
    public PauseManager pause;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        //menu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Pause the game
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            pause.Toggle();
            menu.gameObject.SetActive(true);
            setPause();
        }

        // Unpause the game
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            menu.gameObject.SetActive(false);
            pause.Toggle(); 
            setPause();
        }
    }

    // Change the variable after call
    private void setPause()
    {
        isPaused = !isPaused;
    }

    // Continue button trigger
    public void Continue()
    {
        setPause();
        Time.timeScale = 1;
        menu.gameObject.SetActive(false);
        pause.Toggle();
    }
}
