using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour
    
{
    public static bool inside = false;
    GameObject player;
    public CameraFollow cameraMovement;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraMovement = GameObject.FindGameObjectWithTag("CameraFolder").GetComponent<CameraFollow>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (inside == false)
            {
                if (Input.GetButtonDown("E"))
                {
                    SceneManager.LoadScene("House");
                    inside = true;
                }
            }
            else
            {
                if (Input.GetButtonDown("E"))
                {
                    SceneManager.LoadScene("HomeForest");
                    inside = false;
                }
            }
        }
    }
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        player = GameObject.FindGameObjectWithTag("Player");
        cameraMovement = GameObject.FindGameObjectWithTag("CameraFolder").GetComponent<CameraFollow>();
        cameraMovement.enabled = false;
        cameraMovement.enabled = true;
    }

}
