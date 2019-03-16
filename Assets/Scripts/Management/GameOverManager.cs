using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ragdollas;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        ragdollas = GameObject.FindGameObjectWithTag("PlayerRagdoll");
        ragdollas.SetActive(false);

    }
    private void Update()
    {
        if (player.GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            anim.SetTrigger("GameOver");
            player.GetComponent<SimpleCharacterControl>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            ragdollas.SetActive(true);

        }
    }
}
