using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Rigidbody rb;
    public Transform cube;
    public int forward = 100;
    public int side = 75;
    public int back = 50;
    public int up = 500;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        rb.WakeUp();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(forward * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(-back * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(0, 0, side * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(0, 0,-side * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, up, 0);
        }
        if (playerHealth.currentHealth <= 0)
        {
            rb.Sleep();
        }
    }
}
