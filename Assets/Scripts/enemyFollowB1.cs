using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollowB1 : MonoBehaviour
{

    public float speed;
    private Transform playerPos;
    private Rigidbody2D rb;
    int bossHealth = 14;
    int bossHealthDisplay = 0;
    public static int completeObjective = 0;
    bool hit = true;
    public GameObject bD;
    public Sprite[] bossHealthDisplaySprite;
    public GameObject winCondition;
    public Player Player;
    private AudioSource[] allAudioSources;
    public AudioSource winTheme;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > 0.25f)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }

        if (bossHealthDisplay >= 0)
        {
            bD.GetComponent<SpriteRenderer>().sprite = bossHealthDisplaySprite[bossHealthDisplay];
        }
    }

    void FixedUpdate()
    {
        Rotation();
    }
    void Rotation()
    {
        Vector2 direction = (playerPos.gameObject.GetComponent<Rigidbody2D>().position - rb.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        rb.rotation = angle;
    }

    void StopAllAudio()
    {
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }


    IEnumerator hitCooldown()
    {
        hit = false;
        yield return new WaitForSeconds(2);
        hit = true;
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (hit == true)
            {
                StartCoroutine(hitCooldown());
                bossHealth--;
                bossHealthDisplay++;
                if (bossHealth < 1)
                {
                    bDied();
                }



            }
        }
    }

    void bDied()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StopAllAudio();
        winTheme.Play();
        speed = 0;
        StopAllAudio();
        winTheme.Play();
        winCondition.SetActive(true);
        Player.imDead = true;
        



    }
}
