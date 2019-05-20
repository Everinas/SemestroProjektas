using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestGiver : MonoBehaviour
{

    
    //public Quest quest;
    public GameObject player;

    public Text questPanelTitle;
    public Text questPanelDescription;
    public Text questPanelReward;
    public Text questPanelProgress;

  
    int score;

    
    void Update()
    {
        if (player.GetComponent<CurrentQuest>().friendlyChat == true)
        {

            questPanelTitle.text = "Friendly Chat";
            questPanelDescription.text = "Find an old wizard and have a friendly chat with him";

        }

        if (player.GetComponent<CurrentQuest>().lookingForApples == true)
        {
            
                questPanelReward.gameObject.SetActive(true);
                questPanelProgress.gameObject.SetActive(true);
                score = player.GetComponent<PlayerScore>().currentScore;
                questPanelTitle.text = "Looking For Apples";
                questPanelDescription.text = "Venture out into the wild and collect 10 apples";
                questPanelReward.text = "Reward: Talk with Wizard Arqo about that";

                if (score >= 10)
                {
                    score = 10;
                    Color green = new Color(0F, 0.6F, 0F, 1F);
                    questPanelProgress.color = green;
                }

                questPanelProgress.text = "Progress: (" + score.ToString() + "/10)";
           
        }

       
        if (player.GetComponent<CurrentQuest>().arqosMagic == true)
        {
            
            questPanelTitle.text = "Arqo's Magic";
            questPanelDescription.text = "Find a portal, step on it and see what happens";
            questPanelReward.gameObject.SetActive(false);
            questPanelProgress.gameObject.SetActive(false);

        }
    }
}