using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteManager : MonoBehaviour
{
    public GameObject player;
    Animator anim;

    private void Start()
    {
        // Hide the cursor while playing
        Cursor.visible = false;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player.GetComponent<PlayerScore>().currentScore >= 15)
        {
            // Turn the cursor back on when complete
            Cursor.visible = true;

            // Trigger the LevelComplete view
            anim.SetTrigger("LevelComplete");

            // Maybe define our own character controller?
            player.GetComponent<SimpleCharacterControl>().enabled = false;
        }
    }
}
