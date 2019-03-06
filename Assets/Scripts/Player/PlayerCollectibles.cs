using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectibles : MonoBehaviour
{
    private int collected = 0; //Set up a variable to store how many you've collected

    //This is the text that displayed how many you've collected in the top left corner
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 50, 20), "Collected:" + collected);
    }

    private void OnTriggerEnter(Collider other)
    { //Checks to see if you've collided with another object
        if (other.CompareTag("collectable"))
        { //checks to see if this object is tagged with "collectable"     
            collected++; //adds a count of +1 to the collected variable
            Destroy(other.gameObject); //destroy's the collectable
        }

        // Use this for initializationasdef
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}