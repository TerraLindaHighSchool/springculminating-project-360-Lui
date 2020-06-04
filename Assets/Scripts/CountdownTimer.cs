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
    int countDown;

    public TextMeshProUGUI countdownTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1.0f * Time.deltaTime;
        countDown = Mathf.FloorToInt(currentTime);
        countdownTimer.text = "Time Remaining: " + countDown;
    }
}
