using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuElement : MonoBehaviour
{
    public string sceneToLoad;

    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName.Contains("Level"))
        {
            string levelNumberString = currentSceneName.Substring("Level".Length);

            if (int.TryParse(levelNumberString, out int levelNumber))
            {
                int nextLevel = levelNumber + 1;
                sceneToLoad = "Level" + nextLevel.ToString();
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string sevceToLoad)
    {
        SceneManager.LoadScene(sevceToLoad);
    }   

    public void LoadSceneForLevel()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
