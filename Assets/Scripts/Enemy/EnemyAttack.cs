using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    Vector3 hitDirection;
    public float pushBackForce = 4;

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

            Vector3 direction = new Vector3(0.7f, 0.5f, 0.7f);
            player.GetComponent<Rigidbody>().AddForce(direction * pushBackForce * 75);
            isTouching = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //hitDirection = collision.transform.position - transform.position;
            //hitDirection = hitDirection.normalized;
            //Debug.Log("hitDir" + hitDirection);
            player.GetComponent<Renderer>().material.color = Color.red;
            isTouching = true;
        }
    }

}
