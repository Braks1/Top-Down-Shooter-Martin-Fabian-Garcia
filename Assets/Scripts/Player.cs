using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    int health = 8;
    public bool hit = true;
    public Sprite[] healthDisplay;
    public GameObject hD;
    public int healthDisplayValue = 0;
    public GameObject deathCondition;
    public bool imDead = false;
    public GameObject Ply;
    private AudioSource[] allAudioSources;
    public AudioSource deathSound;
    public enemyFollowB enemyFollowB;


    void Start()
    {
        enemyFollowB.completeObjective = 0;
        health = 8;
        healthDisplayValue = 0;
    }
    void Awake()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (healthDisplayValue >= 0)
        {
            hD.GetComponent<SpriteRenderer>().sprite = healthDisplay[healthDisplayValue];
        }

        if (imDead == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    IEnumerator hitCooldown()
    {
        hit = false;
        yield return new WaitForSeconds(2);
        hit = true;
    }

    void iDied ()
    {

        
        StopAllAudio();
        deathSound.Play();
        imDead = true;
        deathCondition.SetActive(true);
        Ply.GetComponent<EdgeCollider2D>().enabled = false;
        
        

    }

    void StopAllAudio()
    {
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            if (hit == true)
            {
                StartCoroutine(hitCooldown());
                health--;
                healthDisplayValue++;
                if (health < 1)
                {
                    iDied();
                }
                


            }
        }

        if (target.tag == "Boss")
        {
            if (hit == true)
            {
                StartCoroutine(hitCooldown());
                health-= 2;
                healthDisplayValue+= 2;
                if (health < 1)
                {
                    iDied();
                }



            }
        }
    }
}
