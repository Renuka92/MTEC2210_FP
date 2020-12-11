using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UFO SETTINGS")]

    public float UFO_MoveSpeed = 2;
    public float initialUFO_SpawnDelay;
    public float timeBetweenUFO_Spawns;

    public static int score;
    //public static int highScore;

    [Header("UI SETTINGS")]
    public bool enableUI;
    public Gradient healthBarGradient;
    public Color textColor;
    public Text scoreText;
    //public Text highScoreText;
    public Text restartText;

    [Header("OTHER SETTINGS")]
    public SoundMananger soundMananger;
    public bool enableAudio;
    public bool enableParticles;
    public float gameTime = 30;

    [HideInInspector]
    public GameObject bulletHolder;

    int enemyCount = 25;
    //int killCountMax = 3;
    Vector2 enemyPos;

    GameObject UFOPrefab;

    float t = 5;

    public static bool gameOver;


    void Start()
    {
        score = 0;

        bulletHolder = new GameObject("BulletHolder");

        t = initialUFO_SpawnDelay;

        UFOPrefab = Resources.Load<GameObject>("UFO") as GameObject;

        //highScore = PlayerPrefs.GetInt("highscore", highScore);

        if (enableUI)
        {
            //targetAmount = healthBar.fillAmount;

            scoreText.color = textColor;
            //highScoreText.color = textColor;
            restartText.color = textColor;

            restartText.gameObject.SetActive(false);
        }

        scoreText.gameObject.SetActive(enableUI);
        //highScoreText.gameObject.SetActive(enableUI);
        restartText.gameObject.SetActive(enableUI);
    }

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameOver = false;
                SceneManager.LoadScene(1);
            }
        }

        //if (score > highScore)
        //{
        //    highScore = score;
        //    PlayerPrefs.SetInt("highscore", highScore);
        //}

        if (enableUI)
        {
            DisplayScores();

            restartText.gameObject.SetActive(gameOver);
        }

        if (!gameOver)
        {
            gameTime -= Time.deltaTime;
            //if (gameTime > 20)
            //{
            //    soundMananger.PlaySoundAtPosition((Vector2)transform.position, 6);
            //}
            //else if (gameTime > 15)
            //{
            //    soundMananger.PlaySoundAtPosition((Vector2)transform.position, 7);
            //}
            //else if (gameTime > 5)
            //{
            //    soundMananger.PlaySoundAtPosition((Vector2)transform.position, 8);
            //}
            //else
            //{
            //    soundMananger.PlaySoundAtPosition((Vector2)transform.position, 9);
            //}
        }

        if (t > 0 || enemyCount == 0)
        {
            t -= Time.deltaTime;
        }
        else
        {
            SpawnUFO();
            t = timeBetweenUFO_Spawns;
        }

        if (enemyCount == 0)
        {
            GameOver();
        }
    }

    void SpawnUFO()
    {
        var pos = new Vector2(5.5f, 3.5f);
        GameObject UFO = Instantiate(UFOPrefab, pos, Quaternion.identity);
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void EnemyCount()
    {
        enemyCount--;
    }

    public void GameOver()
    {
        gameOver = true;
        //DestroyAllGameObjects();
    }

    //public void SetNewFillAmount(int fill, int maxFill)
    //{
    //    targetAmount = (float)fill / (float)maxFill;
    //}

    void DisplayScores()
    {
        scoreText.text = "Score " + GameManager.score.ToString("00");
        //highScoreText.text = "Best " + GameManager.score.ToString("00");
    }

    //public void DestroyAllGameObjects()
    //{
    //    GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

    //    for (int i = 0; i < GameObjects.Length; i++)
    //    {
    //        Destroy(GameObjects[i]);
    //    }
    //}

}
