using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("TRap has been triggered");
        GameManager.Instance.GameOver();
    }
}
