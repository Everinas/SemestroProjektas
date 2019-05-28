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
    GameObject playeris;
    GameObject bossHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        playeris = GameObject.FindGameObjectWithTag("Player");
        if (MainMenuLoading.loading == true)
        {
            Load();
        }
    }
    public void Save()
    {
        SaveGame.Save<Vector3>("Player", player.position);
        SaveGame.Save<int>("Health", playerHealth.currentHealth);
        SaveGame.Save<int>("Score", playerScore.currentScore);
        SaveGame.Save<int>("Keys", playerScore.currentKeys);
        SaveGame.Save<bool>("Shield", PlayerScore.Shield);

        enemySave();
        foreach(GameObject collectible in colectibles)
        {
            SaveGame.Save<bool>(collectible.name, collectible.activeInHierarchy);
        }
        Animator animator = gameSavePanel.GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("ActivateMessage");
        }
        questsave();
        // SaveGame.Save<bool>("Levelchange", NPC_Dialogue.levelchange);

    }
   
    void enemySave()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                SaveGame.Save<Vector3>(enemies[i].GetInstanceID().ToString(), enemies[i].position);
            }
        }
    }
    void enemyLoad()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].position = SaveGame.Load<Vector3>(enemies[i].GetInstanceID().ToString(), enemies[i].position);
            }
        }
    }
    void questsave()
    {
        SaveGame.Save<bool>("FC", playeris.GetComponent<CurrentQuest>().friendlyChat);
        SaveGame.Save<bool>("LA", playeris.GetComponent<CurrentQuest>().lookingForApples);
        SaveGame.Save<bool>("KS", playeris.GetComponent<CurrentQuest>().keyToSuccess);
        SaveGame.Save<bool>("WB", playeris.GetComponent<CurrentQuest>().whatsInTheBox);
        SaveGame.Save<bool>("AM", playeris.GetComponent<CurrentQuest>().arqosMagic);
        SaveGame.Save<bool>("SH", playeris.GetComponent<CurrentQuest>().setForBattle);
        //SaveGame.Save<bool>("FP", playeris.GetComponent<CurrentQuest>().findThePortal);
        //SaveGame.Save<bool>("ICF", playeris.GetComponent<CurrentQuest>().iceCreamFlavor);
        SaveGame.Save<bool>("TF", playeris.GetComponent<CurrentQuest>().theFinale);
    }
    void questload()
    {
        playeris.GetComponent<CurrentQuest>().friendlyChat = SaveGame.Load<bool>("FC");
        playeris.GetComponent<CurrentQuest>().lookingForApples = SaveGame.Load<bool>("LA");
        playeris.GetComponent<CurrentQuest>().keyToSuccess = SaveGame.Load<bool>("KS");
        playeris.GetComponent<CurrentQuest>().whatsInTheBox = SaveGame.Load<bool>("WB");
        playeris.GetComponent<CurrentQuest>().arqosMagic = SaveGame.Load<bool>("AM");
        playeris.GetComponent<CurrentQuest>().setForBattle = SaveGame.Load<bool>("SH");
        //playeris.GetComponent<CurrentQuest>().findThePortal = SaveGame.Load<bool>("FP");
        //playeris.GetComponent<CurrentQuest>().iceCreamFlavor = SaveGame.Load<bool>("ICF");*/
        playeris.GetComponent<CurrentQuest>().theFinale = SaveGame.Load<bool>("TF");
        if (playeris.GetComponent<CurrentQuest>().friendlyChat == true)
        {
            GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueInteraction>().npc.SetTree("FirstMeeting");
        }
        if (playeris.GetComponent<CurrentQuest>().lookingForApples == true)
        {
            GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueInteraction>().npc.SetTree("SecondTalk");
        }
        if (playeris.GetComponent<CurrentQuest>().setForBattle == true)
        {
            GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueInteraction>().npc.SetTree("ArenaTalk");
        }
        if (playeris.GetComponent<CurrentQuest>().theFinale == true)
        {
            bossHealthBar = GameObject.FindGameObjectWithTag("BossHealthBar");
            bossHealthBar.gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueInteraction>().npc.SetTree("BossDefeated");
        }
    }
    public void Load()
    {
        player.position = SaveGame.Load<Vector3>("Player");
        playerHealth.currentHealth = SaveGame.Load<int>("Health");
        playerScore.currentScore = SaveGame.Load<int>("Score");
        playerScore.currentKeys = SaveGame.Load<int>("Keys");
        PlayerScore.Shield = (SaveGame.Load<bool>("Shield"));


        enemyLoad();

        foreach (GameObject collectible in colectibles)
        {
            collectible.SetActive(SaveGame.Load<bool>(collectible.name.ToString()));
        }
        Animator animator = gameLoadPanel.GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("ActivateMessage");
        }
        questload();
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
