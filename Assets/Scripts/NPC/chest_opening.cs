using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest_opening : MonoBehaviour
{
    GameObject player;
    Animator anim;
    PlayerScore playerScore;
    private bool opened;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        playerScore = player.GetComponent<PlayerScore>();
        opened = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("E"))
        {
            if (other.gameObject == player)
            {
                if (opened == false)
                {
                    anim.Play("Shake");
                    anim.Play("New State");
                    print("Veikia");
                    if (PlayerScore.keys > 0)
                    {
                        playerScore.currentKeys--;
                        anim.Play("Open");
                        opened = true;

                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && opened == false)
        {
            anim.Play("New State");
        }
    }
}
