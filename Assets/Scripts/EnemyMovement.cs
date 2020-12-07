﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static float enemySpeedHorizontal = 3;
    public bool UFO;
    public float UFO_Speed = enemySpeedHorizontal;

    GameManager gameManager;
    Rigidbody2D rb;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (UFO)
        {
            transform.position += (Vector3.left * UFO_Speed * Time.deltaTime);
        }
        else
        {
            transform.position += (Vector3.right * enemySpeedHorizontal * Time.deltaTime);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EndBorder")
        {
            if (UFO)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            EnemyKilled();
            Debug.Log("Enemy Killed!");
            if (!UFO)
            {
                gameManager.EnemyCount();
            }
        }

        if (collision.gameObject.tag == "EnemyBoundary")
        {
            gameManager.GameOver();
        }
    }

    public void EnemyKilled()
    {
        gameManager.IncreaseScore();
        Destroy(gameObject);
    }
}
