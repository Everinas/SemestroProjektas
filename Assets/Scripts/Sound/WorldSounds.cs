using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSounds : MonoBehaviour
{
    public AudioClip piano;
    public AudioClip fight;
    public AudioClip boss;
    public AudioClip forest;
    public AudioSource sourceMusic;
    public AudioSource sourceForest;
    private bool isPlayingForest;
    private bool isPlayingMusic;
    void Start()
    {
        isPlayingForest = false;
        isPlayingMusic = false;
        sourceForest.clip = forest;
        sourceMusic.playOnAwake = false;
        sourceForest.playOnAwake = true;
        sourceMusic.PlayOneShot(piano);
        TogglePlayForestSounds();
    }

    void Update(){
        
        
    }

    public void TogglePlayForestSounds(){
        if (!isPlayingForest){
            sourceForest.Play();
            isPlayingMusic = !isPlayingMusic;
        }
        else{
            sourceForest.Stop();
            isPlayingMusic = !isPlayingMusic;
        }
    }

    public void PlayBossMusic(){
        if (SceneManager.GetActiveScene().name == "HomeForest"){
            
        }
    }

    public void TogglePlayChillMusic(){
        if (SceneManager.GetActiveScene().name == "HomeForest"){
            if (!isPlayingMusic)
            {
                sourceMusic.clip = piano;
                sourceMusic.Play();
                isPlayingMusic = !isPlayingMusic;
            }
            else
            {
                sourceMusic.Stop();
                isPlayingMusic = !isPlayingMusic;
            }    
        }
    }

    public void PlayBattleMusic(){
        if (SceneManager.GetActiveScene().name == "HomeForest"){
            
        }
    }
}
