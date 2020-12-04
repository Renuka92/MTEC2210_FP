using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    public float UFO_Speed;
    public float gameTime = 60;

    GameManager gameManager;
    Rigidbody2D rb;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        transform.position += (Vector3.right * UFO_Speed * Time.deltaTime);

        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
        }
        //else

    }
}
