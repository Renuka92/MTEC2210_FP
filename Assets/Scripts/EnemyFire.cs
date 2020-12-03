using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    GameManager gameManager;
    //SoundManager soundManager;

    //[HideInInspector]
    //public float moveSpeed = 4;
    //[HideInInspector]
    //public float moveWaveFreq = 5f;
    //[HideInInspector]
    //public float moveWaveAmp = 0.2f;
    //[HideInInspector]
    //public float dodge = 2;

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

    //float speedMultiplier = 3f;

    //bool bulletFound;
    //bool playerFound;
    bool readyToFire;
    bool hitTaken;
    float t;
    float f;
    //float flashDuration = 0.1f;

    //[HideInInspector]
    public float enemyfireDelay = 1;

    //public float speedModifier;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //if (collision.gameObject.tag == "Player")
    //    //{
    //    //    collision.gameObject.GetComponent<PlayerScript>().PlayerKilled();
    //    //    Debug.Log("took player out");
    //    //    EnemyKilled();
    //    //}
    //}


    //void TakeHit()
    //{
    //    hitTaken = true;

    //    //if (gameManager.enableParticles)
    //    //{
    //    //    hit.Stop();
    //    //    hit.Play();
    //    //}

    //    //soundManager.PlaySoundAtPosition((Vector2)transform.position, 2);

    //    //if (health -1 > 0)
    //    //{
    //    //    health -= 1;
    //    //} else
    //    //{
    //    //    EnemyKilled();
    //    //}
    //}

    void Fire()
    {
        var enemyBulletAmount = enemyBulletHolder.gameObject.GetComponentsInChildren<BulletScript>().Length;

        if (enemyBulletAmount < maxEnemyBulletsOnScreen)
        {
            float firePoint = sr.bounds.size.x / 1.5f;
            Vector2 pos = new Vector2(transform.position.x + firePoint, transform.position.y);
            var enemyBullet = Instantiate(enemyBulletPrefab, pos, Quaternion.identity, enemyBulletHolder);
            enemyBullet.GetComponent<BulletScript>().speed = enemyBulletSpeed;

            //soundManager.PlaySoundAtPosition(pos, 1);
        }
    }
}