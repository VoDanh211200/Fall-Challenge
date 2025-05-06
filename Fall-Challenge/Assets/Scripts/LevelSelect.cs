using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public GameObject buttonPrefab;
    public string[] levels;
    public Transform grid;

    void Start()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            GameObject button = Instantiate(buttonPrefab, grid);
            button.GetComponent<MenuElement>().sceneToLoad = levels[i];
            button.GetComponentInChildren<TextMeshProUGUI>().text = (i+1).ToString();
        }
    }
}
