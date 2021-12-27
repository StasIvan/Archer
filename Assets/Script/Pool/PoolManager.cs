using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    private Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>(); 

    public void CreatePool(GameObject prefab, int count)
    {
        int instanceID = prefab.GetInstanceID();
        if (poolDictionary.ContainsKey(instanceID) == false)
        {
            poolDictionary.Add(instanceID, new Queue<GameObject>());
            GameObject pool = new GameObject(prefab.name + "Pool");
            pool.SetParent(transform);
            for (int i = 0; i < count; i++)
            {
                GameObject poolObject = Instantiate(prefab);
                poolDictionary[instanceID].Enqueue(poolObject);
                poolObject.SetParent(pool);
            }
        }
    }

    public GameObject GetObjectOfPool(int key)
    {
        foreach (var item in poolDictionary[key])
        {
            if (item.activeSelf == false)
            {
                return item;
            }
        }
        return null;
    }
}
