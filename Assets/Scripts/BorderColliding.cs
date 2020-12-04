using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderColliding : MonoBehaviour
{
    //float enemySpeedHorizontal;
    float enemySpeedHorizontal = EnemyMovement.enemySpeedHorizontal;


    void Start()
    {
        //enemySpeedHorizontal = EnemyMovement.enemySpeedHorizontal;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //speedModifier = Random.Range(0.5f, 2);
            Debug.Log("made it here");
            Debug.Log(enemySpeedHorizontal);
            enemySpeedHorizontal *= -1.0f;
        }
    }

}
