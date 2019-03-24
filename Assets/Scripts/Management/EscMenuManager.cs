using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenuManager : MonoBehaviour
{
    bool isPaused;
    Animator anim;
    public PauseManager pause;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Pause the game
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            pause.Toggle();
            // Show the esc menu
            anim.SetTrigger("ShowEscMenu");
            setPause();
        }

        // Unpause the game
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            pause.Toggle();
            // Hide the esc menu
            anim.SetTrigger("HideEscMenu");
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
        pause.Toggle();
        // Hide the esc menu
        anim.SetTrigger("HideEscMenu");
        setPause();
    }
}
