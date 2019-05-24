using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestGiver : MonoBehaviour
{

    
    //public Quest quest;
    public GameObject player;

    // The NPC that is giving the quest
    public GameObject questGiver;
    // Locations the NPC will spawn to after a certain quest
    public GameObject spawns;

    public Text questPanelTitle;
    public Text questPanelDescription;
    public Text questPanelReward;
    public Text questPanelProgress;

    public GameObject portalActivationPanel;

    int score;
    int keys;

    Color black = new Color(0.196F, 0.196F, 0.196F);
    Color green = new Color(0F, 0.6F, 0F, 1F);
    Color red = new Color(0.63F, 0.09F, 0.04F);

    void Update()
    {
        if (player.GetComponent<CurrentQuest>().friendlyChat == true)
        {
            
            questPanelReward.gameObject.SetActive(true);
            questPanelProgress.gameObject.SetActive(false);
            questPanelProgress.color = black;
            questPanelTitle.text = "Friendly Chat";
            questPanelDescription.text = "Find an old wizard and have a friendly chat with him";
            questPanelReward.text = "Reward: Possibly a new friendship";
        }

        if (player.GetComponent<CurrentQuest>().lookingForApples == true)
        {
            
                questPanelReward.gameObject.SetActive(true);
                questPanelProgress.gameObject.SetActive(true);
                questPanelProgress.color = black;
                score = player.GetComponent<PlayerScore>().currentScore;
                questPanelTitle.text = "Looking For Apples";
                questPanelDescription.text = "Venture out into the wild and collect 10 apples";
                questPanelReward.text = "Reward: Talk with Wizard Arqo about that";

                if (score >= 10)
                {
                    score = 10;
                    questPanelProgress.color = green;
                }

                questPanelProgress.text = "Progress: (" + score.ToString() + "/10)";
           
        }

        if (player.GetComponent<CurrentQuest>().keyToSuccess == true)
        {
            questPanelReward.gameObject.SetActive(true);
            questPanelProgress.gameObject.SetActive(true);
            keys = player.GetComponent<PlayerScore>().currentKeys;
            questPanelProgress.color = red;
            questPanelTitle.text = "Key To Success";
            questPanelDescription.text = "Explore the world and try to find a secret KEY. You might need it later. But be careful! Those nasty creatures won't give it to you that easily...";
            questPanelReward.text = "Reward: Literally a key";
            questPanelProgress.text = "Tip: To defeat a monster, jump on his head";

        }

        if (player.GetComponent<CurrentQuest>().whatsInTheBox == true)
        {
            questPanelReward.gameObject.SetActive(true);
            questPanelProgress.gameObject.SetActive(false);
            keys = player.GetComponent<PlayerScore>().currentKeys;
            Color black = new Color(0.196F, 0.196F, 0.196F);
            questPanelProgress.color = black;
            questPanelTitle.text = "What's in the Box";
            questPanelDescription.text = "Find a chest and open it with the key. You might find something cool and useful for the battle.";
            questPanelReward.text = "Reward: A broad piece of defensive armor";
        }

        if (player.GetComponent<CurrentQuest>().arqosMagic == true)
        {
            Animator animator = portalActivationPanel.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("PortalIsActive", true);
            }
            questPanelTitle.text = "Arqo's Magic";
            questPanelDescription.text = "Find a portal, step on it and see what happens";
            questPanelReward.gameObject.SetActive(false);
            questPanelProgress.gameObject.SetActive(false);

        }
    }
}