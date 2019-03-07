using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
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
        if (player.GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            player.GetComponent<SimpleCharacterControl>().enabled = false;
        }
    }
}
