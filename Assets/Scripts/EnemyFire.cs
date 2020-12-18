using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    GameManager gameManager;
    SoundMananger soundMananger;

    //public int health = 3;

    [HideInInspector] public GameObject enemyBulletPrefab;
    [HideInInspector] public GameObject enemyBulletHolderObject;
    [HideInInspector] public Transform enemyBulletHolder;

    [Range(400, 800)] public float enemyBulletSpeed;
    //[Range(1, 15)] public int maxEnemyBulletsOnScreen;

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


        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        var enemyBullet = Instantiate(enemyBulletPrefab, pos, Quaternion.identity, enemyBulletHolder);
        enemyBullet.GetComponent<BulletScript>().speed = enemyBulletSpeed;


        //if (enemyBulletAmount < maxEnemyBulletsOnScreen)
        //{
        //    Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        //    var enemyBullet = Instantiate(enemyBulletPrefab, pos, Quaternion.identity, enemyBulletHolder);
        //    enemyBullet.GetComponent<BulletScript>().speed = enemyBulletSpeed;
        //}

    }
}