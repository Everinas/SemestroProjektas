using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenuManager : MonoBehaviour
{
    public GameObject menu;
    public PauseManager pause;
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pause = gameObject.GetComponent<PauseManager>();
        isPaused = false;
        menu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Pause the game
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {         
            menu.gameObject.SetActive(true);
            pause.Toggle();
            setPause();
        }

        // Unpause the game
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
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
        menu.gameObject.SetActive(false);
        pause.Toggle();
        setPause();     
    }
}
