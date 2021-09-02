using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    [SerializeField] Transform _camera;
    Transform _thisTransform;
    private void Start()
    {
        _thisTransform = transform;
    }
    private void LateUpdate()
    {
        _thisTransform.LookAt(_thisTransform.position + _camera.forward);
    }
}
