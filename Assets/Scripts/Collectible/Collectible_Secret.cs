using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Secret : MonoBehaviour
{
    GameObject player;
    PlayerScore playerScore;

    public float degreesPerSecond = 45.0f;
    public float amplitude = 0.1f;
    public float frequency = 5f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScore = player.GetComponent<PlayerScore>();
        posOffset = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            gameObject.SetActive(false);
            print("Veikia");
        }
    }
    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
