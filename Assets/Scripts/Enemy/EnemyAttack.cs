using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    GameObject player;
    PlayerHealth playerHealth;
    bool isTouching;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        isTouching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            playerHealth.TakeDamage(1);
            isTouching = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Renderer>().material.color = Color.red;
            isTouching = true;
        }
    }

}
