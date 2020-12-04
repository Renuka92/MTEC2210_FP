using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static float enemySpeedHorizontal = 3;
    public static float enemySpeedVertical = 0.5f;

    public bool UFO;
    public float UFO_Speed;
    public float gameTime = 30;

    GameManager gameManager;
    Rigidbody2D rb;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //transform.position += (Vector3.right * enemySpeedHorizontal * Time.deltaTime);
        //transform.position += (Vector3.down * enemySpeedVertical * Time.deltaTime);

        if (UFO)
        {
            transform.position += (Vector3.right * UFO_Speed * Time.deltaTime);
        }
        else
        {
            transform.position += (Vector3.right * enemySpeedHorizontal * Time.deltaTime);
            transform.position += (Vector3.down * enemySpeedVertical * Time.deltaTime);
        }

        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
        }

        //if (transform.position.y > 1)
        //{
        //    transform.position += (Vector3.down * 0.5f * Time.deltaTime);

        //}
        //else
        //{
        //    transform.position += (Vector3.up * 0.5f * Time.deltaTime);

        //}

        //SwitchSpeed();

        //if (transform.position.y > 1)
        //{
        //    transform.position += (Vector3.up * 2 * Time.deltaTime);

        //}


        //Debug.Log(rb.position.y);

        //if (rb.position.y < 0)
        //{
        //    rb.gravityScale *= -1;
        //}

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EndBorder")
        {
            //speedModifier = Random.Range(0.5f, 2);
            enemySpeedHorizontal *= -1.0f;
            if (UFO)
            {
                UFO_Speed *= -1.0f;
            }
        }

        if (collision.gameObject.tag == "EnemyBoundary")
        {
            //speedModifier = Random.Range(0.5f, 2);
            enemySpeedVertical *= -1.0f;
        }

        //    //if (collision.gameObject.tag == "EnemyBoundary")
        //    //{
        //    //    transform.position += (Vector3.down * 2 * Time.deltaTime);
        //    //}
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "EndBorder")
        //{
        //    //speedModifier = Random.Range(0.5f, 2);
        //    enemySpeedHorizontal *= -1.0f;
        //}


        if (collision.gameObject.tag == "PlayerBullet")
        {
            EnemyKilled();
            //Destroy(gameObject);
            //score = score++;
            Debug.Log("Enemy Killed!");
        }
    }

    public void EnemyKilled()
    {
        //Vector2 pos = transform.position;
        gameManager.IncreaseScore();
        Destroy(gameObject);
        //        gameManager.IncreaseKillCounter(pos);
    }
}
