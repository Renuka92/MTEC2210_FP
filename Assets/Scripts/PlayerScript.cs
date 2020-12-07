using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // SPACE INVADERS!!!
    public GameManager gameManager;
    public SoundMananger soundManager;

    public float playerSpeed;
    public Rigidbody2D rb;
    public float inputMovement;

    [Header("PLAYER SETTINGS")]

    [Range(1, 10)] public int playerHealth = 4;
    public float moveSpeed = 6;
    [Range(10, 1000)] public float bulletSpeed = 600;

    [Range(1, 10)] public int maxBulletsOnScreen = 8;
    public float autofireDelay = 0.1f;

    bool autofire = true;
    bool hitTaken;
    bool ready;

    Vector2 defaultPos;
    //Vector2 velocity;

    float t;
    float f;
    float inputDelayFactor;

    [HideInInspector] public int maxPlayerHealth;

    GameObject bulletPrefab;
    Transform bulletHolder;

    SpriteRenderer sr;

    public KeyCode leftKey;
    public KeyCode rightKey;

    private void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("PlayerBullet") as GameObject;

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        //bulletHolder = gameManager.bulletHolder.transform;

        t = autofireDelay;

        defaultPos = transform.position;

        //maxPlayerHealth = playerHealth;

        autofireDelay = Mathf.Abs(autofireDelay);

        ready = false;
        inputDelayFactor = 0.5f;
    }

    void Update()
    {
        if (ready)
        {
            MovePlayer();
        }
        else
        {
            DelayInput();
        }

        bulletHolder = gameManager.bulletHolder.transform;


        if (Input.GetKey(KeyCode.Space))
        {
            if (autofire)
            {
                if (t > 0)
                {
                    t -= Time.deltaTime;
                } else
                {
                    Fire();
                    t = autofireDelay;
                }
            }
        }

        if (hitTaken)
        {
            if (f > 0)
            {
                sr.color = Color.red;
                f -= Time.deltaTime;
            } else
            {
                sr.color = Color.white;
                hitTaken = false;
            }
        }
    }

    void MovePlayer()
    {
        if (Input.GetKey(rightKey))
        {
            inputMovement = 1;
        }
        else if (Input.GetKey(leftKey))
        {
            inputMovement = -1;
        }
        else 
        {
            inputMovement = 0;
        }

        float xMove = inputMovement * playerSpeed * Time.deltaTime;

        Vector2 movement = new Vector2(xMove, 0);
        rb.velocity = movement;
    }

    void Fire()
    {
        var bulletAmount = bulletHolder.gameObject.GetComponentsInChildren<BulletScript>().Length;

        if (bulletAmount < maxBulletsOnScreen)
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            var bullet = Instantiate(bulletPrefab, pos, Quaternion.identity, bulletHolder);
            bullet.GetComponent<BulletScript>().speed = bulletSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            TakeHit();
        }

        if (collision.gameObject.tag == "EndBorder")
        {
            inputMovement = 0;
        }
    }

    void TakeHit()
    {
        hitTaken = true;
        Debug.Log("Player Killed!");
        PlayerKilled();

        //if (playerHealth - 1 > 0)
        //{
        //    playerHealth -= 1;

        //    //if (gameManager.enableParticles)
        //    //{
        //    //    hit.Stop();
        //    //    hit.Play();
        //    //}

        //    //gameManager.SetNewFillAmount(playerHealth, maxPlayerHealth);
        //}
        //else
        //{
        //    PlayerKilled();
        //}
    }

    public void PlayerKilled()
    {
        gameManager.SetNewFillAmount(0, maxPlayerHealth);
        gameManager.GameOver();
        Destroy(gameObject);
    }

    void DelayInput()
    {
        if (inputDelayFactor > 0)
        {
            inputDelayFactor -= Time.deltaTime;
        } else
        {
            ready = true;
        }
    }

    public void IncreaseHealth(int amount)
    {
        if (playerHealth + amount < maxPlayerHealth)
        {
            playerHealth += amount;
        } else
        {
            playerHealth = maxPlayerHealth;
        }
    }
}
