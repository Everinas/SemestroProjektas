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
    public Text questPanelProgress;

    int score;


    Color green = new Color(0F, 0.6F, 0F, 1F);

    void Update()
    {
        if (quest.isActive)
        {

            questPanelReward.gameObject.SetActive(true);
            questPanelProgress.gameObject.SetActive(true);
            score = player.GetComponent<PlayerScore>().currentScore;
            questPanelTitle.text = quest.questTitle;
            questPanelDescription.text = quest.questDescription;
            questPanelReward.text = "Reward: " + quest.reward;

            if (score >= 10)
            {
                score = 10;
                questPanelProgress.color = green;
            }

            questPanelProgress.text = "Progress: (" + score.ToString() + "/10)";
        }
        else
        {
            questPanelTitle.text = "Quest";
            questPanelDescription.text = "You currently don't have an active quest";
            questPanelReward.text = "Reward:";
            questPanelProgress.text = "Progress";
            questPanelReward.gameObject.SetActive(false);
            questPanelProgress.gameObject.SetActive(false);
        }
    }
}