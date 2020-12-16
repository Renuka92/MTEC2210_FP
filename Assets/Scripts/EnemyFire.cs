using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    GameManager gameManager;
    SoundMananger soundMananger;

    //[HideInInspector]
    //public int health = 3;

    public GameObject enemyBulletPrefab;
    public GameObject enemyBulletHolderObject;
    public Transform enemyBulletHolder;
    public float enemyBulletSpeed = 600;
    public int maxEnemyBulletsOnScreen = 10;

    Rigidbody2D rb;
    SpriteRenderer sr;

    bool readyToFire;
    bool hitTaken;
    float f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundMananger = GameObject.Find("SoundManager").GetComponent<SoundMananger>();

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        enemyBulletHolderObject = new GameObject("EnemyBulletHolder");
        enemyBulletHolder = enemyBulletHolderObject.transform;
    }

    void Update()
    {
        Fire();

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