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
        //Vector3 targetposition = new Vector3(transform.position.x,
        //                                     player.transform.position.y,
        //                                     transform.position.z);
        if (isTouching)
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            funk();
            //player.transform.LookAt(transform.localPosition);
            isTouching = false;
        }
    }
    void funk()
    {
        Vector3 toTarget = (transform.position - player.transform.position).normalized;

        if (Vector3.Dot(toTarget, player.transform.forward) > 0)
        {
            playerHealth.TakeDamage(1);
            player.GetComponent<Rigidbody>().AddRelativeForce(0, 3, -7, ForceMode.VelocityChange);
        }
        else
        {
            // if(has a shield)
            player.GetComponent<Rigidbody>().AddRelativeForce(0, 3, 4, ForceMode.VelocityChange);
            //else
            //playerHealth.TakeDamage(1);
            //player.GetComponent<Rigidbody>().AddRelativeForce(0, 3, 7, ForceMode.VelocityChange);
        }
    }
private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hitDirection = collision.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            isTouching = true;
        }
    }

}
