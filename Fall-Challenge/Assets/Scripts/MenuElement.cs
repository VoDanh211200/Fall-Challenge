using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuElement : MonoBehaviour
{
    public string sceneToLoad;
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
