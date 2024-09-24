using System;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    [SerializeField] float farthestZ = 28f;
    float speed = 5f;
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime; // Constant movement
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RoadCollider")
        {
            transform.position = new Vector3(0, 0, farthestZ + transform.position.z);
        }
    }
}
