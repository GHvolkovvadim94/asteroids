using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    Rigidbody rb;
    void Awake()
    {
       rb = gameObject.GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("Столкновение с препятствием!");
        }
        if (collision.collider.CompareTag("Star"))
        {
            Debug.Log("Сбор звезды");
        }
        Destroy(collision.collider.gameObject);
    }
}
