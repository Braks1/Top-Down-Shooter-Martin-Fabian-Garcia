using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    private List<Rigidbody2D> EnemyRbs;
    public float speed;
    private Transform playerPos;
    private Rigidbody2D rb;

    private float repelRange = .5f;


    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        if (EnemyRbs == null)
        {
            EnemyRbs = new List<Rigidbody2D>();
        }

        EnemyRbs.Add(rb);
    }


    private void OnDestroy()
    {
        EnemyRbs.Remove(rb);
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
        Vector2 repelforce = Vector2.zero;
        foreach (Rigidbody2D enemy in EnemyRbs)
        {
            if (enemy == rb)
                continue;

            if (Vector2.Distance(enemy.position, rb.position) <= repelRange)
            {
                Vector2 repelDir = (rb.position - enemy.position).normalized;
                repelforce += repelDir;
            }
        }
    }
}
