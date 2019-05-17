using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using System;
using BayatGames.SaveGameFree.Types;
using BayatGames.SaveGameFree.Examples;

public class Saving2 : MonoBehaviour
{
    public Transform player;
    public Transform[] enemies;
    public GameObject[] colectibles; 
    public PlayerScore playerScore;
    public PlayerHealth playerHealth;

    public GameObject gameSavePanel;
    public GameObject gameLoadPanel;

    // Start is called before the first frame update
    void Start()
    {
    }
    void Save()
    {
        SaveGame.Save<Vector3>("Player", player.position);
        SaveGame.Save<int>("Health", playerHealth.currentHealth);
        SaveGame.Save<int>("Score", playerScore.currentScore);
        SaveGame.Save<int>("Keys", playerScore.currentKeys);
        foreach(Transform enemy in enemies)
        {
            SaveGame.Save<Vector3>(enemy.GetInstanceID().ToString(), enemy.position);
        }
        foreach(GameObject collectible in colectibles)
        {
            SaveGame.Save<bool>(collectible.GetInstanceID().ToString(), collectible.activeInHierarchy);
        }
        Animator animator = gameSavePanel.GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("ActivateMessage");
        }
        
        // SaveGame.Save<bool>("Levelchange", NPC_Dialogue.levelchange);

    }
    void Load()
    {
        player.position = SaveGame.Load<Vector3>("Player");
        playerHealth.currentHealth = SaveGame.Load<int>("Health");
        playerScore.currentScore = SaveGame.Load<int>("Score");
        playerScore.currentKeys = SaveGame.Load<int>("Keys");
        foreach (Transform enemy in enemies)
        {
            enemy.position = SaveGame.Load<Vector3>(enemy.GetInstanceID().ToString(), enemy.position);
        }
        foreach (GameObject collectible in colectibles)
        {
            collectible.SetActive(SaveGame.Load<bool>(collectible.GetInstanceID().ToString()));
        }
        Animator animator = gameLoadPanel.GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("ActivateMessage");
        }
        //NPC_Dialogue.levelchange = SaveGame.Load<bool>("Levelchange");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("P"))
        {
            Save();
        }
        if (Input.GetButtonDown("L"))
        {
            Load();
        }
    }
}
