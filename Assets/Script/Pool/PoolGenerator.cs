using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolGenerator : MonoBehaviour
{
    [Serializable]
    public class PoolData
    {
        public PoolObject poolObject;
        public int count;
    }

    [SerializeField] private List<PoolData> _pools;

    private void Start()
    {
        GeneratePools();
    }

    private void GeneratePools()
    {
        foreach (var item in _pools)
        {
            PoolManager.Instance.CreatePool(item.poolObject.gameObject, item.count);
        }
    }
}
