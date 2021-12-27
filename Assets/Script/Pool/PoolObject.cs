using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private Transform _poolParent;

    private void Start()
    {
        this.SetInactive();
    }

    public void Destroy()
    {
        this.SetInactive();
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        transform.SetParent(_poolParent);
    }
}
