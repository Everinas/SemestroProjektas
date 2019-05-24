using UnityEngine;
using UnityEngine.UI;

public class DialogueInteraction : MonoBehaviour {

    [SerializeField]
    public Dialogues npc;

    [SerializeField]
    Text dialogueText;
    [SerializeField]
    Text leftText;
    [SerializeField]
    Text rightText;
    [SerializeField]
    Text middleText;
    [SerializeField]
    GameObject backPanel;
    [SerializeField]
    GameObject nextTreeButton;
    public PlayerScore score;
    PlayerScore playerScore;
    private GameObject player;
    CameraFollow cameraMovement;

    public GameObject portalActivationPanel;

    public GameObject key;

    bool nextEnd = false;

    // Simple Dialogues //
    // This is a basic example of how you can use the dialogue system. //

    
	public void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScore = player.GetComponent<PlayerScore>();
        cameraMovement = GameObject.FindGameObjectWithTag("CameraFolder").GetComponent<CameraFollow>();
        npc.SetTree("FirstMeeting"); //This sets the current tree to be used. Resets to the first node when called.
        Hide();
        //backPanel.SetActive(false);
        //nextTreeButton.SetActive(false);

    }

    public void Show()
    {
        if (npc.GetCurrentTree() == "SecondTalk")
        {
            npc.SetTree("SecondTalk"); //This sets the current tree to be used. Resets to the first node when called.
        }
        if (npc.GetCurrentTree() == "1QuestDone")
        {
            npc.SetTree("1QuestDone"); //This sets the current tree to be used. Resets to the first node when called.
        }
        if (playerScore.currentScore >= 10)
        {
            npc.SetTree("1QuestDone"); //This sets the current tree to be used. Resets to the first node when called.
        }
        if (npc.GetCurrentTree() == "ArenaTalk")
        {
            npc.SetTree("ArenaTalk"); //This sets the current tree to be used. Resets to the first node when called.
        }
        if (PlayerScore.Shield == true)
        {
            npc.SetTree("ArenaTalk"); //This sets the current tree to be used. Resets to the first node when called.
        }
        if (npc.GetCurrentTree() == "BossDefeated")
        {
            npc.SetTree("BossDefeated"); //This sets the current tree to be used. Resets to the first node when called.
        }
        if (player.GetComponent<CurrentQuest>().theFinale == true && player.GetComponent<QuestGiver>().bossHP == 0)
        {
            npc.SetTree("BossDefeated"); //This sets the current tree to be used. Resets to the first node when called.
        }
        nextEnd = false;
        Cursor.visible = true;
        cameraMovement.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<SimpleCharacterControl>().enabled = false;
        backPanel.SetActive(true);
        nextTreeButton.SetActive(false);
        Display();
    }

    public void Choice(int index)
    {
        if (index == 2 && npc.GetCurrentTree() == "TalkAgain") index = 1;
        if (npc.GetChoices().Length != 0)
        {
            npc.NextChoice(npc.GetChoices()[index]); //We make a choice out of the available choices based on the passed index.
            Display();                               //We actually call this function on the left and right button's onclick functions
        }
        else
        {
            Progress();
        }
    }

    public void TalkAgain()
    {
        Show();
    }

    public void Progress()
    {
        npc.Next(); //This function returns the number of choices it has, in my case I'm checking that in the Display() function though.
        Display();
    }
    public void Hide()
    {

            backPanel.SetActive(false);
            nextTreeButton.SetActive(false);
        }
        public void Display()
    {
        if (nextEnd == true)
        {
            backPanel.SetActive(false);
            nextTreeButton.SetActive(true);
        }
        else
        {
            backPanel.SetActive(true);
            nextTreeButton.SetActive(false);
        }

        //Sets our text to the current text
        dialogueText.text = npc.GetCurrentDialogue();
        //Just debug log our triggers for example purposes
        if (npc.HasTrigger())
            Debug.Log("Triggered: "+npc.GetTrigger());
        //This checks if there are any choices to be made
        if (npc.GetChoices().Length == 1)
        {
            //Setting the text's of the buttons to the choices text, in my case I know I'll always have a max of three choices for this example.
            leftText.text = npc.GetChoices()[0];
            leftText.transform.parent.gameObject.SetActive(true);
            rightText.transform.parent.gameObject.SetActive(false);
            middleText.transform.parent.gameObject.SetActive(false);
        }
        if (npc.GetChoices().Length == 2)
        {
            leftText.text = npc.GetChoices()[0];
            middleText.text = npc.GetChoices()[1];
            leftText.transform.parent.gameObject.SetActive(true);
            rightText.transform.parent.gameObject.SetActive(false);
            middleText.transform.parent.gameObject.SetActive(true);
        }
        if (npc.GetChoices().Length == 3)
        {
            leftText.text = npc.GetChoices()[0];
            middleText.text = npc.GetChoices()[1];
            rightText.text = npc.GetChoices()[2];
            leftText.transform.parent.gameObject.SetActive(true);
            rightText.transform.parent.gameObject.SetActive(true);
            middleText.transform.parent.gameObject.SetActive(true);
        }
        if (npc.GetChoices().Length == 0)
        {
            middleText.text = "Continue";
            //Setting the appropriate buttons visability
            leftText.transform.parent.gameObject.SetActive(false);
            rightText.transform.parent.gameObject.SetActive(false);
            middleText.transform.parent.gameObject.SetActive(true);
        }

        if (npc.End()) //If this is the last dialogue, set it so the next time we hit "Continue" it will hide the panel
        {
            nextEnd = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<SimpleCharacterControl>().enabled = true;
            cameraMovement.enabled = true;
            playerScore.kazkas = 1;
            if (npc.GetCurrentTree() == "FirstMeeting")
            {
                player.GetComponent<CurrentQuest>().friendlyChat = false;
                player.GetComponent<CurrentQuest>().lookingForApples = true;
                npc.SetTree("SecondTalk"); //This sets the current tree to be used. Resets to the first node when called.
            }
            if (npc.GetCurrentTree() == "1QuestDone")
            {
                player.GetComponent<CurrentQuest>().lookingForApples = false;
                player.GetComponent<CurrentQuest>().keyToSuccess = true;
                key.gameObject.SetActive(true);
            }
            if (npc.GetCurrentTree() == "ArenaTalk")
            {
                player.GetComponent<CurrentQuest>().setForBattle = false;
                player.GetComponent<CurrentQuest>().arqosMagic = true;
                NPC_Dialogue.levelchange = true;
                Animator animator = portalActivationPanel.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetBool("PortalIsActive", true);
                }
            }
            Hide();
        }

    }
}
