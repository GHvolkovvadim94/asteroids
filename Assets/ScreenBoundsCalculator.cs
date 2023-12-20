using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundsCalculator : MonoBehaviour
{
    private float minX, maxX, minY, maxY;

    void Start()
    {
        CalculateScreenBounds();
    }
    public void CalculateScreenBounds()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            Vector3 lowerLeftCorner = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
            Vector3 upperRightCorner = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane));

            minX = lowerLeftCorner.x;
            maxX = upperRightCorner.x;
            minY = lowerLeftCorner.y;
            maxY = upperRightCorner.y;
        }
        else
        {
            Debug.LogError("Основная камера не найдена!");
        }
    }

    // Добавленные методы для возвращения значений краев экрана
    public float GetMinX() { return minX; }
    public float GetMaxX() { return maxX; }
    public float GetMinY() { return minY; }
    public float GetMaxY() { return maxY; }


}
