using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    public GameObject dotPrefab;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePis = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPos = Camera.main.ScreenToWorldPoint(mousePis);
            Instantiate(dotPrefab, objPos, Quaternion.identity);
        }
    }
}
