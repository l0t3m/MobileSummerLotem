using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    float farthestZ = 56f; // Furthest road's Z
    float speed = 15f; // The speed of the world moving

    [SerializeField] UnityEngine.Object CoinObject;
    [SerializeField] GameObject RoadParent;
    [SerializeField] GameObject CollectibleParent;
    [SerializeField] private int RoadIndex;

    private void Start()
    {
        int difficulty = PlayerPrefs.GetInt("Difficulty", 1);
        switch (difficulty)
        {
            case 1:
                speed *= 1.25f;
                break;
            case 2:
                speed *= 1.5f;
                break;
        }
    }
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime; // Constant movement
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RoadCollider")
        {
            if (gameObject.tag == "Ground")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, farthestZ + transform.position.z);
                RoadIndex+=15;
                if (RoadIndex % 6 == 0)
                {
                    ObstacleSpawner.instance.SpawnObstacle();
                }
                else if (RoadIndex % 8 == 0)

                    Instantiate(CoinObject, new Vector3(UnityEngine.Random.Range(-1, 2) * 3.5f, 1f, farthestZ), new Quaternion(0, 0, 0, 0), CollectibleParent.transform);
            }
            else
                Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Obstacle" && collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            LossHandler.Instance.OnDeath();
        }
    }
}
