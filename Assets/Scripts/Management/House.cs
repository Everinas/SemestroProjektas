using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour
    
{
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
            if (SceneManager.GetActiveScene().name == "HomeForest")
            {
                if (Input.GetButtonDown("E"))
                {
                    SceneManager.LoadScene("House");
                }
            }
            if(SceneManager.GetActiveScene().name == "House")
            {
                if (Input.GetButtonDown("E"))
                {
                    SceneManager.LoadScene("HomeForest");
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
