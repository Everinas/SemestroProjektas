using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightManager : MonoBehaviour
{
    public GameObject arenaLocation;
    public GameObject player;
    public GameObject boss;
    public GameObject NPC;

    // During the fight: spawn the teleport points which teleport you to the top of the arena
    // From there, you can jump on top of the boss and damage it
    // On win: change the lighting back to normal, and teleport the npc to the center of the arena
    public void StartBossFight()
    {
        // Start the boss music
        // Change the scene lighting
        // spawn the teleport points which teleport you to the top of the arena
    }

    public void OnBossKill()
    {
        // Spawn the NPC in the center
        NPC.transform.position = arenaLocation.transform.position;
        
        // Stop the music
        
        // Change the scene lighting
    }
}
