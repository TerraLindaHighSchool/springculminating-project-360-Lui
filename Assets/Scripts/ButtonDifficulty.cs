using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDifficulty : MonoBehaviour
{

    private Button button;
    public SpawnManager spawnManager;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        spawnManager.StartGame(difficulty);
    }
}
