using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleOnPickUp : MonoBehaviour
{
    GameObject player;
    PlayerScore playerScore;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScore = player.GetComponent<PlayerScore>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Destroy(this.gameObject);
            player.GetComponent<Renderer>().material.color = Color.green;
            playerScore.currentScore++;
        }
    }
}
