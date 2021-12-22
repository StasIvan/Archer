using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [HideInInspector] public Transform thisTransform;

    private void Start()
    {
        thisTransform = transform;
    }

    private void LateUpdate()
    {
        thisTransform.LookAt(thisTransform.position + _camera.forward);
    }
}
