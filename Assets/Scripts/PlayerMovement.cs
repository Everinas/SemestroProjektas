using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cube;
    public int forward = 100;
    public int side = 75;
    public int back = 50;

    // Update is called once per frame
    void Update()
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
        
    }
}
