using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    //[SerializeField] private GameObject powerup;

    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 8.0f;
    private float zPowerupRange = 5.0f;
    private float ySpawn = 0.75f;

    private float powerupSpawnTime = 5.0f;
    public float startDelay = 1.0f;

    public bool isGameActive = false;
    public GameObject titleScreen;
    public GameObject title;
    public GameObject playScreen;
    public GameObject endGame;
    public TextMeshProUGUI healthText;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;

        if (health <= 0)
        {
            EndGame();
        }
    }

    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        //Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }

    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
        playScreen.gameObject.SetActive(true);

        if(isGameActive)
        {
            InvokeRepeating("SpawnRandomEnemy", startDelay, difficulty);
            InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
        }
    }

    public void EndGame()
    {
        CancelInvoke();
        isGameActive = false;
        endGame.gameObject.SetActive(true);
        playScreen.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
