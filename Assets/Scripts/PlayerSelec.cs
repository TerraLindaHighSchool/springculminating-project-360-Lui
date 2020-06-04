using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerSelec : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;
    public SpawnManager planeScreen1;
    public SpawnManager titleScreen1;
    
    // Start is called before the first frame update
    private void Start()
    {
        planeScreen1 = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        titleScreen1 = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        foreach(GameObject go in characterList)
        {
            go.SetActive(false); 
        }

        if(characterList[0])
        {
            characterList[0].SetActive(true);
        }
    }

    public void ToggleLeft()
    {
        characterList[index].SetActive(false);

        index--;
        if(index < 0)
        {
            index = characterList.Length - 1;
        }

        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        characterList[index].SetActive(true);
    }

    public void ConfirmButton()
    {
        titleScreen1.titleScreen.SetActive(true);
        planeScreen1.planeScreen.SetActive(false);
    }
}
