using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] walkSounds;
    [SerializeField]
    private AudioClip[] NPCSounds;
    [SerializeField]
    private AudioClip[] playerHurtSounds;
    public AudioClip jumpSound;
    public AudioClip fallSound;
    public AudioClip pickUpSound;
    public AudioClip healthSound;
    public AudioClip keySound;
    public AudioClip shieldSound;
    public AudioClip teleportSound;
    public GameObject player;
    private AudioSource source; 
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            source.PlayOneShot(jumpSound);
        }
    }

    public void Step(){
        AudioClip step = walkSounds[UnityEngine.Random.Range(0, walkSounds.Length)];
        source.PlayOneShot(step, (float)0.5);
    }

    public void NPCTalk(){
        AudioClip talk = NPCSounds[UnityEngine.Random.Range(0, NPCSounds.Length)];
        source.PlayOneShot(talk, (float)0.4);
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.name == "Terrain"){
            source.PlayOneShot(fallSound);
        }
    }

    public void PlayPlayerHurtSound(){
        AudioClip hurt = playerHurtSounds[UnityEngine.Random.Range(0, playerHurtSounds.Length)];
            source.PlayOneShot(hurt, (float)0.4);
    }

    public void PlayPickUpSound(){
        source.PlayOneShot(pickUpSound, (float)0.4);
    }

    public void PlayPickUpHealthSound(){
        source.PlayOneShot(healthSound, (float)0.4);
    }

    public void PlayPickUpKeySound(){
        source.PlayOneShot(keySound, (float)0.4);
    }

    public void PlayPickUpShieldSound(){
        source.PlayOneShot(shieldSound, (float)0.4);
    }
    public void PlayTeleportSound(){
        source.PlayOneShot(teleportSound, (float)0.4);
    }
}
