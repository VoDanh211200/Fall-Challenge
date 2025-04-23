using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text scoreText, livesText;
    public GameObject ball;

    private int score;
    private int lives = 3;
    private Rigidbody2D ballRb;
    private Vector2 ballStartPos;
    private float distanceToCamera;
    private float lastYPos;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateTextElements();
        ballRb = ball.GetComponent<Rigidbody2D>();
        ballStartPos = ball.transform.position;
        distanceToCamera = ballStartPos.y;
        lastYPos = ballStartPos.y;
    }

    private void LateUpdate()
    {
        if (ball.transform.position.y <= Camera.main.transform.position.y)
        {
            Vector3 oldCamPos = Camera.main.transform.position;
            Vector3 newCamPos = new Vector3(oldCamPos.x, oldCamPos.y - 1f, oldCamPos.z);
            Camera.main.transform.position = Vector3.Lerp(oldCamPos, newCamPos, 2f * Time.deltaTime);
        }
    }

    public void GameOver()
    {
        ballStartPos.y = Camera.main.transform.position.y + distanceToCamera;
        ball.transform.position = ballStartPos;
        ballRb.velocity = Vector2.zero;

        lives--;
        UpdateTextElements();

        if (lives <= 0)
        {
            ballRb.isKinematic = true;
        }
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
