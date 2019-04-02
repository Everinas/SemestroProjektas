using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree.Types;
using BayatGames.SaveGameFree.Encoders;
using BayatGames.SaveGameFree.Serializers;
using BayatGames.SaveGameFree.Examples;
using BayatGames.SaveGameFree;

public class Saving : MonoBehaviour
{
    public int score;

    private void Start()
    {
        score = SaveGame.Load<int>("Score");
        PlayerHealth.health = SaveGame.Load<int>("Health");
        PlayerScore.score = score;
    }
    private void OnTriggerEnter(Collider other)
    {
        SaveGame.Save<int>("Score", PlayerScore.score);
        SaveGame.Save<int>("Health", PlayerHealth.health);
        score = SaveGame.Load<int>("Score");
    }
    
}
