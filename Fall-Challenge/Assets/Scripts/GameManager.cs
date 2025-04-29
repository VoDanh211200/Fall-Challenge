using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameModes
    {
        LEVEL,
        ENDURANCE
    }

    public GameModes gameMode;
    public GameObject ball;
    public GameObject fx_Destroy;

    [Header("ENDURANCE")]
    public Text scoreText, livesText;
    public List<GameObject> trapPrefabs = new List<GameObject>();
    public Transform spawPoint;
    public GameObject gameoverPanel;

    [Header("LEVEL")]
    public GameObject winPanel;

    private int score;
    private int lives = 3;
    private Rigidbody2D ballRb;
    private Vector2 ballStartPos;
    private float distanceToCamera;
    private float lastYPos;
    private float distanceToNewSpaw = 5f;
    private float travelDistance;
    private List<GameObject> spawnedTraps = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameoverPanel.SetActive(false);
        ballRb = ball.GetComponent<Rigidbody2D>();

        if (gameMode == GameModes.ENDURANCE)
        {
            StartCoroutine(DeleteTraps());
            UpdateTextElements();
            ballStartPos = ball.transform.position;
            distanceToCamera = ballStartPos.y;
            lastYPos = ballStartPos.y;
        }
        else
        {
            winPanel.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        if (gameMode == GameModes.ENDURANCE)
        {
            if (ball.transform.position.y <= Camera.main.transform.position.y)
            {
                Vector3 oldCamPos = Camera.main.transform.position;
                Vector3 newCamPos = new Vector3(oldCamPos.x, oldCamPos.y - 1f, oldCamPos.z);
                Camera.main.transform.position = Vector3.Lerp(oldCamPos, newCamPos, 3f * Time.deltaTime);
            }

            travelDistance = lastYPos - ball.transform.position.y;
            if (travelDistance >= distanceToNewSpaw)
            {
                lastYPos = ball.transform.position.y;
                travelDistance = 0;
                CreateNewTrap();
            }
        }
    }

    private void CreateNewTrap()
    {
        int index = Random.Range(0, trapPrefabs.Count - 1);
        Vector3 spawPos = new(-2f, lastYPos - distanceToNewSpaw, 1);
        GameObject newTrap = Instantiate(trapPrefabs[index], spawPos, Quaternion.identity);
        spawnedTraps.Add(newTrap);
    }

    private void DeleteTrapsAboveCam(float distance)
    {
        for (int i = spawnedTraps.Count - 1; i >= 0; i--)
        {
            if (spawnedTraps[i].transform.position.y > Camera.main.transform.position.y + distance)
            {
                Destroy(spawnedTraps[i]);
                spawnedTraps.RemoveAt(i);
            }
        }
    }

    private void DeleteAllTraps()
    {
        for (int i = spawnedTraps.Count - 1; i >= 0; i--)
        {
            Destroy(spawnedTraps[i]);
            spawnedTraps.RemoveAt(i);
        }
    }

    private IEnumerator DeleteTraps()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            DeleteTrapsAboveCam(5f);
        }
    }

    public void GameOver()
    {
        if (gameMode == GameModes.ENDURANCE)
        {
            Instantiate(fx_Destroy, ball.transform.position, Quaternion.identity);
            ballStartPos.y = Camera.main.transform.position.y + distanceToCamera;
            ball.transform.position = ballStartPos;
            ballRb.velocity = Vector2.zero;

            lives--;
            DeleteTrapsAboveCam(0);
            UpdateTextElements();

            if (lives <= 0)
            {
                ballRb.isKinematic = true;
                DeleteAllTraps();
                StopCoroutine(DeleteTraps());
                gameoverPanel.SetActive(true);
            }
        }

        if (gameMode == GameModes.LEVEL)
        {
            Instantiate(fx_Destroy, ball.transform.position, Quaternion.identity);
            ball.SetActive(false);
            gameoverPanel.SetActive(true);
        }
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
    }

    public void AddScore()
    {
        score++;
        UpdateTextElements();
    }

    private void UpdateTextElements()
    {
        scoreText.text = "Score: " + score.ToString("D4");
        livesText.text = "Lives: " + lives;
    }
}
