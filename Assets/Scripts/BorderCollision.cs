using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    public GameObject enemyReference;
    public SoundMananger soundMananger;
    //public int soundNum = 6;

    void Start()
    {
        enemyReference = GameObject.FindGameObjectWithTag("Enemy");
        soundMananger = GameObject.Find("SoundManager").GetComponent<SoundMananger>();

    }

    private void Update()
    {
        //soundMananger.PlaySoundAtPosition((Vector2)transform.position, soundNum);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float enemyVertical = enemyReference.transform.position.y;


        if (collision.gameObject.tag == "Enemy")
        {
            EnemyMovement.enemySpeedHorizontal *= -1.0f;
            enemyVertical -= 0.05f;
            enemyReference.transform.position = new Vector3(0, enemyVertical, 0);
            //soundNum ++;
            //soundMananger.PlaySoundAtPosition((Vector2)transform.position, 1);

        }
    }
}
