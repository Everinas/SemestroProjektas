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

    void Start()
    {
        questPanelTitle.text = quest.questTitle;
        questPanelDescription.text = quest.questDescription;
        questPanelReward.text = "Reward: " + quest.reward;
    }
}