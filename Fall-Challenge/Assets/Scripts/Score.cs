using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    bool scoreAlready;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.gameMode == GameManager.GameModes.ENDURANCE && !scoreAlready)
        {
            print("Score has been triggered");
            scoreAlready = true;
            GameManager.Instance.AddScore();
        }

        if (GameManager.Instance.gameMode == GameManager.GameModes.LEVEL && !GameManager.Instance.gameoverPanel.activeSelf)
        {
            print("Score has been triggered");           
            GameManager.Instance.WinGame();
        }
    }
}
