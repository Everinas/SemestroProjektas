using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public GameObject player;

    public Text questPanelTitle;
    public Text questPanelDescription;
    public Text questPanelReward;
    public Text questProgress;


    void Update()
    {
        if (quest.isActive)
        {
            //player.GetComponent<PlayerScore>()
            questPanelTitle.text = quest.questTitle;
            questPanelDescription.text = quest.questDescription;
            questPanelReward.text = "Reward: " + quest.reward;
        }
    }
}