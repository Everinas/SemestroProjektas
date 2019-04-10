using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Dialogue : MonoBehaviour
{
    public string firstStage;
    public string secondStage;
    public string thirdStage;
    public Text dialogue;
    public static bool levelchange = false;
    public static bool buttonPress = false;
    public static bool wave = false;
    Collider player;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("E") && buttonPress == false)
        {
            player = other;
            //Vector3 targetPostition = new Vector3(other.transform.position.x,
            //                           this.transform.position.y,
            //                           other.transform.position.z);
            //this.transform.LookAt(targetPostition);
            
            if (wave == false)
            {
                wave = true;
                other.GetComponent<Animator>().Play("wave");
            }
            buttonPress = true;
            if (PlayerScore.score >= 5)
            {
                if (PlayerScore.score >= 10)
                {
                    dialogue.text = thirdStage;
                    levelchange = true;
                }
                else
                    dialogue.text = secondStage;
            }
            else
            {
                dialogue.text = firstStage;
            }
        }
        else if (Input.GetButtonDown("E") && buttonPress == true)
        {
            buttonPress = false;
            dialogue.text = "";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            buttonPress = false;
            dialogue.text = "";
            wave = false;
        }
    }
    void start()
    {
        Rigidbody mm_Rigidbody;
        mm_Rigidbody = GetComponent<Rigidbody>();
        //This locks the RigidBody so that it does not move or rotate in the Z axis.
        mm_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
    }
     void Update()
    {
        if (wave == true)
        {
            Vector3 targetDir = player.transform.position - transform.position;
            targetDir.y = 0;
            float step = 2 * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);

            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
