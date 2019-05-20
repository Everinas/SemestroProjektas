using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public GameObject obj;
    public GameObject teleportPoint;

    void OnTriggerStay()
    {
        if (Input.GetButtonDown("E"))
        {
             obj.transform.position = teleportPoint.transform.position;        
        }
    }
}
