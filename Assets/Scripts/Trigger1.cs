using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    public GameObject oldText2;
    public GameObject newText2;
    public GameObject boss;
    public GameObject lightss;
    public GameObject bossBar;
    public GameObject flashlight;
    public GameObject door1;
    public AudioSource backgroundMusic1;
    public AudioSource finalBoss;
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            backgroundMusic1.Stop();
            finalBoss.Play();
            oldText2.SetActive(false);
            newText2.SetActive(true);
            lightss.SetActive(true);
            flashlight.SetActive(false);
            bossBar.SetActive(true);
            boss.SetActive(true);
            door1.SetActive(true);
            Destroy(gameObject);
        }
    }
}
