using System;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    float farthestZ = 28f; // Furthest road's Z
    float speed = 10f; // The speed of the world moving


    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime; // Constant movement
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RoadCollider")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, farthestZ + transform.position.z);
        }
    }
}
