using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //[Header("ENEMY SETTINGS")]

    //public float enemyMoveSpeed;
    //public float enemyMoveWaveFrequency;
    //public float enemyMoveWaveAmplitude;
    //[Range(1, 10)] public int enemyHealth;
    //public float enemyDodgeAmount;
    //public float enemyBulletDetectionRadius;
    //public float enemyBulletDetectionDistance;
    //public float initialEnemySpawnDelay;
    //public float timeBetweenEnemySpawns;
    //[Range(1, 10)] public int maxEnemiesOnScreen;

    //public float enemyBulletSpeed;
    //public float enemyFireDelay;
    //[Range(1, 15)] public int maxEnemyBulletsOnScreen;

    public static int score;
    //public static int highScore;

    [Header("UI SETTINGS")]
    public bool enableUI;
    public Gradient healthBarGradient;
    public Color textColor;
    public Text scoreText;
    //public Text highScoreText;
    public Text restartText;
    //public Image healthBar;
    float targetAmount;

    [Header("OTHER SETTINGS")]
    //public SoundManager soundManager;
    public bool enableAudio;
    public bool enableParticles;

    [HideInInspector]
    public GameObject enemyBulletHolder;
    [HideInInspector]
    public GameObject bulletHolder;

    int killCount;
    //int killCountMax = 3;
    Vector2 enemyPos;

    GameObject enemyPrefab;
    GameObject enemyBulletPrefab;

    //float xPos = 9.5f;
    //float t;

    public static bool gameOver;


    void Start()
    {
        score = 0;

        enemyBulletHolder = new GameObject("EnemyBulletHolder");
        bulletHolder = new GameObject("BulletHolder");

        //t = initialEnemySpawnDelay;

        //enemyPrefab = Resources.Load<GameObject>("Enemy") as GameObject;
        enemyBulletPrefab = Resources.Load<GameObject>("EnemyBullet") as GameObject;

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
        //healthBar.gameObject.SetActive(enableUI);

    }

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameOver = false;
                SceneManager.LoadScene(0);
            }
        }

        //if (score > highScore)
        //{
        //    highScore = score;
        //    PlayerPrefs.SetInt("highscore", highScore);
        //}

        if (enableUI)
        {
            //float s = 5;
            //healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, targetAmount, s * Time.deltaTime);
            //healthBar.color = healthBarGradient.Evaluate(healthBar.fillAmount);

            DisplayScores();

            restartText.gameObject.SetActive(gameOver);
        }
    }

    public void IncreaseScore()
    {
        score += 1;
    }

    public void IncreaseKillCounter(Vector2 pos)
    {
        killCount++;
        enemyPos = pos;
    }

    public void GameOver()
    {
        gameOver = true;
        //DestroyAllGameObjects();
    }

    public void SetNewFillAmount(int fill, int maxFill)
    {
        targetAmount = (float)fill / (float)maxFill;
    }

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
