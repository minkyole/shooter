using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform waveSpawnPoint;
    public GameObject[] waves;

    public float[] waveDelays;
    public bool spawningWaves;
    private int waveTracker;

    public GameObject[] powerUps;
    public int powerUpChance;

    public float powerUpLength;
    private float powerUpCounter;
    private float playerSpeed;
    private PlayerController player;

    public float speedMultiplier;
    public int playerLives;
    public Transform playerSpawnPoint;
    public GameObject explosion;

    public GameObject gameOverScreen;
    public Text liveText;
    public Text scoreText;

    public int currentScore;
    public GameObject bossBattle;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerSpeed = player.moveSpeed;
        liveText.text = "Lives: " + playerLives;
        scoreText.text = "Score: " + currentScore;
    }

    void Update()
    {
        if (spawningWaves)
        {
            waveDelays[waveTracker] -= Time.deltaTime;
            if (waveDelays[waveTracker] < 0)
            {
                Instantiate(waves[waveTracker], waveSpawnPoint.position, waveSpawnPoint.rotation);
                waveTracker++;
                if (waveTracker >= waveDelays.Length)
                {
                    spawningWaves = false;

                    if (bossBattle != null)
                    {
                        bossBattle.SetActive(true);
                    }
                }
            }
        }

        if (powerUpCounter > 0)
        {
            powerUpCounter -= Time.deltaTime;

            if (powerUpCounter <= 0)
            {
                player.moveSpeed = playerSpeed;
            }
        }
    }

    public void DropPowerUp(Vector3 enemyPosition)
    {
        if (Random.Range(0, 100) < powerUpChance)
        {
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], enemyPosition, new Quaternion(0, 0, 0, 0));
        }
    }

    public void ActivateSpeedPower()
    {
        powerUpCounter = powerUpLength;
        player.moveSpeed = playerSpeed * speedMultiplier;
    }

    public void KillPlayer()
    {
        Debug.Log("Player hurt!");
        playerLives -= 1;

        liveText.text = "Lives: " + playerLives;
        if (playerLives > 0)
        {
            Instantiate(explosion, player.transform.position, player.transform.rotation);
            player.gameObject.SetActive(false);
            player.moveSpeed = playerSpeed;
            player.doubleShot = false;
            player.transform.position = playerSpawnPoint.position;
            player.gameObject.SetActive(true);
            player.shield.SetActive(true);
        }
        else
        {
            liveText.text = "ALL LIVES LOST!";
            Instantiate(explosion, player.transform.position, player.transform.rotation);
            player.gameObject.SetActive(false);
            Invoke("DelayGameOver", 1.5f);
        }
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = "Score: " + currentScore;
    }

    public void AddLife()
    {
        playerLives++;
        liveText.text = "Lives: " + playerLives;
    }

    public void DelayGameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
