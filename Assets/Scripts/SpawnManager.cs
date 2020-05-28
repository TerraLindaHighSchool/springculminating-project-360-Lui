using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public GameObject playScreen;
    public GameObject endGame;
    public TextMeshProUGUI healthText;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        healthText.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        isGameActive = true;
        while (isGameActive)
        { 
            titleScreen.gameObject.SetActive(false);
            playScreen.gameObject.SetActive(true);

            InvokeRepeating("SpawnRandomEnemy", startDelay, difficulty);
            InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);

            if (health <= 0)
            {
                EndGame();
            }
        }
    }

    public void EndGame()
    {
        isGameActive = false;
        endGame.gameObject.SetActive(true);


    }
}
