using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    //Set up a variable to store how many you've collected
    private int startScore = 0;
    public int currentScore;
    private int startKeys = 0;
    public int currentKeys;
    public static int score; //Needed for NPC_dialogue
    public static int keys; //Needed for NPC_dialogue
    public static bool Shield;
    public Text counter;
    public Text Keys;
    private GameObject player;
    public static GameObject PlayerShield;
    public int kazkas;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerShield = GameObject.FindGameObjectWithTag("PlayerShield");
        currentScore = startScore;
        currentKeys = startKeys;
        counter.text = "Score: 0";
        Keys.text = "Keys: 0";
        kazkas = 1;
        Shield = false;
        PlayerShield.SetActive(false);
    }



    private void Update()
    {
        counter.text = "Score: " + currentScore.ToString();
        Keys.text = "Keys: " + currentKeys.ToString();

        if (currentKeys >= 1 && player.GetComponent<CurrentQuest>().keyToSuccess == true)
        {
            player.GetComponent<CurrentQuest>().keyToSuccess = false;
            player.GetComponent<CurrentQuest>().whatsInTheBox = true;
        }
    }
}
