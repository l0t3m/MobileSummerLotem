using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;

    [SerializeField] private float obstacleSpawnDistance = 56f;
    [SerializeField] Object[] VehicleObstacles;
    [SerializeField] Object[] LowObstacles;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnObstacle()
    {
        int obstacleAmount = UnityEngine.Random.Range(1, 4);
        int[] positions = new int[] { -2, -2, -2 };
        for (int i = 0; i < obstacleAmount; i++)
        {
            positions[i] = GenerateObstaclePosition(positions[0], positions[1]);
            int objectType = (i == 0 && obstacleAmount == 3) ? 1 : UnityEngine.Random.Range(0, 2);
            if (objectType == 0)
                Instantiate(VehicleObstacles[UnityEngine.Random.Range(0, VehicleObstacles.Length)], new Vector3(obstaclePositions[positions[i]], 0f, farthestZ), new Quaternion(0, 0, 0, 0), RoadParent.transform);
            else
                Instantiate(LowObstacles[UnityEngine.Random.Range(0, LowObstacles.Length)], new Vector3(obstaclePositions[positions[i]], 0f, farthestZ), new Quaternion(0, 0, 0, 0), RoadParent.transform);
        }
    }

    private int GenerateObstaclePosition(int pos1, int pos2)
    {
        var exclude = new HashSet<int>() { pos1, pos2 };
        var range = Enumerable.Range(0, 3).Where(i => !exclude.Contains(i));

        var rand = new System.Random();
        int index = rand.Next(0, 3 - exclude.Count);
        return range.ElementAt(index);
    }
}