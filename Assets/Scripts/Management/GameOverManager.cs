using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ragdollas;
    public Follow cameraMovement;
    Animator anim;

    private void Start()
    {
        // Hide the cursor when playing
        Cursor.visible = false;

        // This stops the camera movement after dying
        cameraMovement = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Follow>();

        // Init animator for endgame buttons
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");
        ragdollas = GameObject.FindGameObjectWithTag("PlayerRagdoll");
        ragdollas.SetActive(false);

    }
    private void Update()
    {
        if (player.GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            // Stop the camera movement
            cameraMovement.enabled = false;

            // Turn on the cursor back after dying
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Show the endgame buttons
            anim.SetTrigger("GameOver");

            player.GetComponent<SimpleCharacterControl>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            ragdollas.SetActive(true);
        }
    }
}
