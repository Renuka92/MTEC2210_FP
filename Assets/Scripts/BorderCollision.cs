using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    float enemySpeedHorizontal = EnemyMovement.enemySpeedHorizontal;
    float enemySpeedVertical = EnemyMovement.enemySpeedVertical;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemySpeedHorizontal *= -1.0f;
            enemySpeedVertical *= -1.0f;
        }
    }
}
