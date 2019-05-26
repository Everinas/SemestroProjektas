using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject healthBar;
    public GameObject border1;
    public GameObject border2;
    public GameObject border3;
    public GameObject border4;
    public GameObject enemy;
    public GameObject green;
    public GameObject orange;
    public GameObject red;

    public AudioClip death;
    public AudioClip damage;

    void Start()
    {
        border1.gameObject.SetActive(true);
        border2.gameObject.SetActive(true);
        border3.gameObject.SetActive(true);
        border4.gameObject.SetActive(true);
        green.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        float hp = enemy.GetComponent<BreadcrumbAi.Ai>().Health;

        if (hp <= 0)
        {
            healthBar.gameObject.SetActive(false);
            enemy.GetComponent<AudioSource>().PlayOneShot(death);
        }
        if (hp >= 2 && hp < 3)
        {
            green.gameObject.SetActive(false);
            orange.gameObject.SetActive(true);
            enemy.GetComponent<AudioSource>().PlayOneShot(damage);
        }
        if (hp >= 1 && hp < 2)
        {
            orange.gameObject.SetActive(false);
            red.gameObject.SetActive(true);
            enemy.GetComponent<BreadcrumbAi.Ai>().followSpeed = 4;
            enemy.GetComponent<BreadcrumbAi.Ai>().wanderSpeed = 3f; 
            enemy.GetComponent<AudioSource>().PlayOneShot(damage);         
        }
    }
}
