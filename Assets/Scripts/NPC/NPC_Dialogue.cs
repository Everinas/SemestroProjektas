using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Dialogue : MonoBehaviour
{
    public string firstStage;
    public string secondStage;
    public string thirdStage;
    public Text dialogue;
    public static bool levelchange = false;
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerScore.score >= 5)
        {
            if (PlayerScore.score >= 10)
            {
                dialogue.text = thirdStage;
                levelchange = true;
            }
            else
            dialogue.text = secondStage;
        }
        else
        {
            dialogue.text = firstStage;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogue.text = "";
        }
    }
}
