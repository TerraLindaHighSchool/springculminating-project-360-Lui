using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0.0f;
    float startingTime = 60.0f;
    public int countDown = 60;
    public SpawnManager gameT;

    public TextMeshProUGUI countdownTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        gameT = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (gameT.isGameActive)
        {
            currentTime -= 1.0f * Time.deltaTime;
            countDown = (int)currentTime;
            countdownTimer.text = "Time Remaining: " + countDown;
        }
    }
}
