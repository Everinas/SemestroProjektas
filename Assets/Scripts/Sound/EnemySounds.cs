using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{  
    [SerializeField]
    public AudioClip[] deathSounds; 
    private AudioSource source;
    private bool isDead;
    
    void Start()
    {
        source = this.GetComponent<AudioSource>();
        source.playOnAwake = false;
        isDead = false;
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        if (this.GetComponent<BreadcrumbAi.Ai>().Health < 1 && !isDead){
            AudioClip death = deathSounds[UnityEngine.Random.Range(0, deathSounds.Length)];
            source.PlayOneShot(death, (float)0.4);
        }     
    }
}
