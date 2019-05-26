using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public AudioClip dialogueSound;
    public AudioSource source;
    void Start()
    {
        source.playOnAwake = false;   
    }

    public void PlayHoverSound(){
        source.PlayOneShot(hoverSound, (float)0.5);
    }

    public void PlayClickSound(){
        source.PlayOneShot(clickSound, (float)0.5);
    }

    public void PlayDialogueButtonSound(){
        source.PlayOneShot(dialogueSound, (float)0.4);
    }
}
