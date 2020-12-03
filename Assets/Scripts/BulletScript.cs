using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rb;

    [HideInInspector]
    public float speed;

    public bool enemyBullet;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (enemyBullet)
        {
            rb.velocity = (Vector2.down * speed * Time.deltaTime);
        } else
        {
            rb.velocity = (Vector2.up * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enemyBullet || (enemyBullet && collision.gameObject.tag != "Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
