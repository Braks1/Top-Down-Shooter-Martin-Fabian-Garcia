using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollowB : MonoBehaviour
{

    public float speed;
    private Transform playerPos;
    private Rigidbody2D rb;
    int enemyHealth = 3;
    public static int completeObjective = 0;
    public GameObject door;
    public GameObject oldText1;
    public GameObject newText1;
    public AudioSource fightMusic;
    public AudioSource backgroundMusic;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > 0.25f)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemyHealth--;
            if (enemyHealth < 1)
            {
                objectiveCounter();
                Destroy(gameObject);
                
            }
        }
    }

    void objectiveCounter()
    {
        completeObjective++;

        if (completeObjective >= 12)
        {
            door.SetActive(false);
            oldText1.SetActive(false);
            newText1.SetActive(true);
            fightMusic.Stop();
            backgroundMusic.Play();
        }
            
    }
}
