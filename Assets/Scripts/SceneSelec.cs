using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelec : MonoBehaviour
{
    public SpawnManager pScreen;
    public SpawnManager sScreen;

    // Start is called before the first frame update
    void Start()
    {
        pScreen = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        sScreen = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SunB()
    {
        sScreen.sceneScreen.SetActive(false);
        pScreen.planeScreen.SetActive(true);     
    }

    public void NightB()
    {
        sScreen.sceneScreen.SetActive(false);
        pScreen.planeScreen.SetActive(true);
        SceneManager.LoadScene("Night Setting");
    }

    public void RainB()
    {
        sScreen.sceneScreen.SetActive(false);
        pScreen.planeScreen.SetActive(true);
        SceneManager.LoadScene("Rain Setting");
    }

    public void SnowB()
    {
        sScreen.sceneScreen.SetActive(false);
        pScreen.planeScreen.SetActive(true);
        SceneManager.LoadScene("Snow Setting");
    }
}
