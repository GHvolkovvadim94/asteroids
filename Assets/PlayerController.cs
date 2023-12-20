using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private float minX, maxX, minY, maxY;
    public float padding = 0.5f; // Размер отступа



    void Start()
    {
        // Получаем компонент ScreenBounds
        ScreenBoundsCalculator screenBounds = GetComponent<ScreenBoundsCalculator>();
        if (screenBounds != null)
        {
            // Вычисляем границы экрана
            screenBounds.CalculateScreenBounds();
            // Получаем значения краев экрана
            minX = screenBounds.GetMinX() + padding;
            maxX = screenBounds.GetMaxX() - padding;
            minY = screenBounds.GetMinY() + padding;
            maxY = screenBounds.GetMaxY() - padding;
        }
        else
        {
            Debug.LogError("Компонент ScreenBounds не найден!");
        }
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Вычисляем новую позицию
        Vector3 newPosition = transform.position + new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;

        // Ограничиваем координаты в пределах границ
        float clampedX = Mathf.Clamp(newPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(newPosition.y, minY, maxY);

        // Устанавливаем новую позицию
        transform.position = new Vector3(clampedX, clampedY, newPosition.z);
    }
}
