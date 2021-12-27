using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private int _instanceID;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        GetInstanceIDBullet();
    }

    private void GetInstanceIDBullet()
    {
        _instanceID = bullet.GetInstanceID();
    }

    //private void Update()
    //{
    //    if (_rb.velocity.sqrMagnitude < 0.1f)
    //    {
    //        GameObject currentBullet = PoolManager.Instance.GetObjectOfPool(_instanceID);
    //        if (currentBullet != null)
    //        {
    //            Transform transformBullet = PoolManager.Instance.GetObjectOfPool(_instanceID).transform;
    //            transformBullet.SetActive();
    //            transformBullet.SetPositionAndRotation(transform.position + transform.forward, Quaternion.identity);
    //            transformBullet.DOMove(transform.forward * 5f + transform.position, 3f);
    //        }
    //    }
    //}

}
