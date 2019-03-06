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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Destroy(this.gameObject);
            playerScore.currentScore++;
        }
    }
}
