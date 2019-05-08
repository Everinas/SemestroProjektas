using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour
    
{
    public static bool inside = false;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (inside == false)
            {
                if (Input.GetButtonDown("E"))
                {
                    SceneManager.LoadScene("House");
                    inside = true;
                }
            }
            else
            {
                if (Input.GetButtonDown("E"))
                {
                    SceneManager.LoadScene("HomeForest");
                    inside = false;
                }
            }
        }
    }

}
