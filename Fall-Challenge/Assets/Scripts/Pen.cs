using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    public GameObject dotPrefab;
    public GameObject gameoverPanel;

    void Update()
    {
        if (Input.GetMouseButton(0) && gameoverPanel.activeSelf == false)
        {
            Vector2 mousePis = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPos = Camera.main.ScreenToWorldPoint(mousePis);
            Instantiate(dotPrefab, objPos, Quaternion.identity);
        }
    }
}
