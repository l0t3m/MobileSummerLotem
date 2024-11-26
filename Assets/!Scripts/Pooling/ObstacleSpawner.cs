using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;

    [SerializeField] private float obstacleSpawnDistance = 56f;
    private float[] obstaclePositions = new float[] { -3.5f, 0f, 3.5f };
    

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
            positions[i] = GenerateExcludedInt(positions[0], positions[1], 3);
            string obstacleType = ((i == 0 && obstacleAmount == 3) || UnityEngine.Random.Range(0, 2) == 0) ? "lowObstacle" : "vehicleObstacle";
            ObjectPooler.instance.SpawnFromPool(obstacleType, new Vector3(obstaclePositions[positions[i]], 0f, obstacleSpawnDistance));
        }
    }

    public int GenerateExcludedInt(int pos1, int pos2, int length)
    {
        var exclude = new HashSet<int>() { pos1, pos2 };
        var range = Enumerable.Range(0, length).Where(i => !exclude.Contains(i));

        var rand = new System.Random();
        int index = rand.Next(0, length - exclude.Count);
        return range.ElementAt(index);
    }
}