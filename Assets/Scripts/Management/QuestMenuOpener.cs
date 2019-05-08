using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenuOpener : MonoBehaviour
{
    public GameObject questPanel;

    //public void OpenPanel()
    //{
    //    if (questPanel != null)
    //    {
    //        questPanel.SetActive(true);
    //    }
    //}

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (questPanel != null)
            {
                questPanel.SetActive(true);
            }
        }
        else
        {
            if (questPanel != null)
            {
                questPanel.SetActive(false);
            }
        }



    }
}

