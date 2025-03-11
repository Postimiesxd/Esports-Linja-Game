using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private RectTransform crosshair;

    void Start()
    {
        crosshair = GetComponent<RectTransform>();
        Cursor.visible = false; // Hide default mouse cursor
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        crosshair.position = mousePosition; // Move crosshair to mouse position
    }
}
