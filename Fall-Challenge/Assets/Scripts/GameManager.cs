using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text scoreText, livesText;

    private int score;
    private int lives =3;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateTextElements();
    }

    public void GameOver()
    {
        lives--;
        UpdateTextElements();
    }

    public void AddScore()
    {
        score++;
        UpdateTextElements();
    }

    void UpdateTextElements()
    {
        scoreText.text = "Score: " + score.ToString("D4");
        livesText.text = "Lives: " + lives;
    }
}
