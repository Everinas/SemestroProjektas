using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerShield;
    public GameObject RagdollShield;
    public GameObject ragdollas;
    public CameraFollow cameraMovement;
    bool dead;
    public GameObject overMenu;
    


    private void Start()
    {
        // Hide the cursor when playing
        Cursor.visible = false;
        dead = false;
        // This stops the camera movement after dying
        cameraMovement = GameObject.FindGameObjectWithTag("CameraFolder").GetComponent<CameraFollow>();

        // Init animator for endgame buttons
        overMenu.gameObject.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player");
        ragdollas = GameObject.FindGameObjectWithTag("PlayerRagdoll");
        ragdollas.SetActive(false);

    }
    private void Update()
    {
        if (player.GetComponent<PlayerHealth>().currentHealth <= 0 && dead == false)
        {
            // Stop the camera movement
            cameraMovement.enabled = false;
            if(PlayerScore.Shield == true)
            {
                playerShield = GameObject.FindGameObjectWithTag("PlayerShield");
                RagdollShield = GameObject.FindGameObjectWithTag("RagdollShield");
                playerShield.SetActive(false);
                ragdollas.SetActive(true);
            }
            else
            {                            
                RagdollShield = GameObject.FindGameObjectWithTag("RagdollShield");
                ragdollas.SetActive(true);
                RagdollShield.SetActive(false);
            }
            // Turn on the cursor back after dying
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Show the endgame buttons
            overMenu.gameObject.SetActive(true);

            player.GetComponent<Rigidbody>().isKinematic = true;
            player.GetComponent<BoxCollider>().enabled = false;
            player.GetComponent<SimpleCharacterControl>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            dead = true;
        }
    }
}
