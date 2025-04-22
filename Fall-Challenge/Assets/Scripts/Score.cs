using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    bool scoreAlready;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!scoreAlready) 
        {
            print("Score has been triggered");
            scoreAlready = true;
            GameManager.Instance.AddScore();
        }
    }
}
