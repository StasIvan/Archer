using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private bool destroyActivated;
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

    public virtual void OnObjectReuse()
    {
        destroyActivated = false;
    }

    public void Destroy(float t)
    {
        if (!destroyActivated)
        {
            destroyActivated = true;
            StartCoroutine(DestroyRoutine(t));
            OnObjectReuse();
        }
    }

    public void ReturnToPool()
    {
        transform.SetParent(_poolParent);
    }

    public void SetPoolParent(Transform parent)
    {
        _poolParent = parent;
    }

    private IEnumerator DestroyRoutine(float t)
    {
        yield return new WaitForSeconds(t);
        Destroy();
    }
}
