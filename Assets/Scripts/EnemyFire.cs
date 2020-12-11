using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    GameManager gameManager;
    SoundMananger soundMananger;

    //[HideInInspector]
    //public int health = 3;

    //[HideInInspector]
    public GameObject enemyBulletPrefab;
    //[HideInInspector]
    public Transform enemyBulletHolder;
    //[HideInInspector]
    public int maxEnemyBulletsOnScreen = 10;
    //[HideInInspector]
    public float enemyBulletSpeed = 600;

    //public GameObject psHit;
    //public GameObject enemyAfterburner;
    ParticleSystem hit;

    Rigidbody2D rb;
    SpriteRenderer sr;

    bool readyToFire;
    bool hitTaken;
    float t;
    float f;

    //[HideInInspector]
    public float enemyfireDelay = 1;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundMananger = GameObject.Find("SoundManager").GetComponent<SoundMananger>();

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        enemyBulletHolder = gameManager.enemyBulletHolder.transform;
        enemyBulletPrefab = Resources.Load<GameObject>("EnemyBullet") as GameObject;

    }

    void Update()
    {
        Fire();

        if (hitTaken)
        {
            //Destroy(gameObject);
            if (f > 0)
            {
                sr.color = Color.red;
                f -= Time.deltaTime;
            } else
            {
                sr.color = Color.white;
                //f = flashDuration;
                hitTaken = false;
            }
        }

    }

    void TakeHit()
    {
        hitTaken = true;

        //soundMananger.PlaySoundAtPosition((Vector2)transform.position, 2);

        //if (health -1 > 0)
        //{
        //    health -= 1;
        //} else
        //{
        //    EnemyKilled();
        //}
    }

    void Fire()
    {
        var enemyBulletAmount = enemyBulletHolder.gameObject.GetComponentsInChildren<BulletScript>().Length;

        if (enemyBulletAmount < maxEnemyBulletsOnScreen)
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            var enemyBullet = Instantiate(enemyBulletPrefab, pos, Quaternion.identity, enemyBulletHolder);
            enemyBullet.GetComponent<BulletScript>().speed = enemyBulletSpeed;
        }
    }
}