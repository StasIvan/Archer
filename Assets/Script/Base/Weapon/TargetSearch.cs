using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSearch : MonoBehaviour
{
    public Action<Transform> SetTargetEvent;

    private SphereCollider _searchSphere;
    private Coroutine _searchTargetCoroutine;

    private void Start()
    {
        _searchSphere = GetComponent<SphereCollider>();
        _searchTargetCoroutine = StartCoroutine(Search());
    }

    private void OnTriggerEnter(Collider other)
    {
        SetTargetEvent?.Invoke(other.transform);
        //if (_searchTargetCoroutine != null)
        //{
        //    StopCoroutine(_searchTargetCoroutine);
        //    _searchTargetCoroutine = null;
        //}
        ResetRadius();
    }

    private IEnumerator Search()
    {
        while (true)
        {
            _searchSphere.radius += 0.1f;
            yield return null;
        }
    }

    private void ResetRadius()
    {
        _searchSphere.radius = 1f;
    }
}
