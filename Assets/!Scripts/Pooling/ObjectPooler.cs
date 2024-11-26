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
    public Dictionary<string, List<GameObject>> PoolDict;

    GameObject spawnObj;
    private void Start()
    {
        PoolDict = new Dictionary<string, List<GameObject>>();
        foreach (var pool in pools)
        {
            List<GameObject> objList = new List<GameObject>();
            for (int i = 0; i < pool.prefabs.Length; i++)
            {
                for (int j = 0; j < pool.size; j++)
                {
                    GameObject obj = (GameObject)Instantiate(pool.prefabs[i], pool.parent);
                    obj.SetActive(false);
                    objList.Add(obj);
                }            
            }
            PoolDict.Add(pool.type, objList);
        }
    }

    public GameObject SpawnFromPool(string type, Vector3 position)
    {
        if (!PoolDict.ContainsKey(type))
        {
            Debug.LogWarning("Pool doesn't have pooltype " + type);
            return null;
        }
        do       
            spawnObj = PoolDict[type][Random.Range(0, PoolDict[type].Count)];
        while (spawnObj.activeInHierarchy);

        spawnObj.SetActive(true);
        spawnObj.transform.position = position;

        return spawnObj;
    }
}
