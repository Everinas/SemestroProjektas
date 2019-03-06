using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteManager : MonoBehaviour
{
    public GameObject player;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player.GetComponent<PlayerScore>().currentScore >= 15)
        {
            anim.SetTrigger("LevelComplete");
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
