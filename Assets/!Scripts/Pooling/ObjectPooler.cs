using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string type;
        public Object[] prefabs;
        public Transform parent;
        public int size;
    }

    public static ObjectPooler instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> PoolDict;

    GameObject spawnObj;
    private void Start()
    {
        PoolDict = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                for (int j = 0; j < pool.prefabs.Length; j++)
                {
                    GameObject obj = (GameObject)Instantiate(pool.prefabs[j], pool.parent);
                    obj.SetActive(false);
                    objPool.Enqueue(obj);
                }            
            }
            PoolDict.Add(pool.type, objPool);
        }
    }

    public GameObject SpawnFromPool(string type, Vector3 position)
    {
        if (!PoolDict.ContainsKey(type))
        {
            Debug.LogWarning("Pool doesn't have pooltype " + type);
            return null;
        }

        spawnObj = PoolDict[type].Dequeue();
        spawnObj.SetActive(true);
        spawnObj.transform.position = position;

        PoolDict[type].Enqueue(spawnObj);
        return spawnObj;
    }
}
