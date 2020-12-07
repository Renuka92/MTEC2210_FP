using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    public GameObject enemyReference;

    void Start()
    {
        enemyReference = GameObject.FindGameObjectWithTag("Enemy");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float enemyVertical = enemyReference.transform.position.y;


        if (collision.gameObject.tag == "Enemy")
        {
            EnemyMovement.enemySpeedHorizontal *= -1.0f;
            enemyVertical -= 0.05f;
            enemyReference.transform.position = new Vector3(0, enemyVertical, 0);

        }
    }
}
