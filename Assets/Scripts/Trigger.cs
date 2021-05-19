using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject oldText;
    public GameObject newText;
    public GameObject zombies;
    public AudioSource fightMusic;
    public AudioSource backgroundMusic;
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            oldText.SetActive(false);
            newText.SetActive(true);
            zombies.SetActive(true);
            backgroundMusic.Pause();
            fightMusic.Play();
            Destroy(gameObject);
        }
    }
}
