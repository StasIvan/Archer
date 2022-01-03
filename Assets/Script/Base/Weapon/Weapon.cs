using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private TargetSearch _targetSearch;
    [SerializeField] private float _reloadTime;

    [HideInInspector] public Transform thisTransform;

    private int _instanceID;
    private Movement _movement;
    private Transform _target;
    
    private void Awake()
    {
        _targetSearch.SetTargetEvent += SetTarget;
    }

    private void Start()
    {
        Init();
    }

    private void OnDisable()
    {
        _targetSearch.SetTargetEvent -= SetTarget;
    }

    private void Init()
    {
        _movement = GetComponent<Movement>();
        thisTransform = transform;
        GetInstanceIDBullet();
        StartCoroutine(ShootEnemy());
        StartCoroutine(LookAtTarget());
    }

    private void GetInstanceIDBullet()
    {
        _instanceID = bullet.GetInstanceID();
    }

    private IEnumerator ShootEnemy()
    {
        while (true)
        {
            if (_movement.IsObjectMove(thisTransform) == false && _target != null)
            {
                GameObject currentBullet = PoolManager.Instance.GetObjectOfPool(_instanceID);
                if (currentBullet != null)
                {
                    Transform transformBullet = currentBullet.transform;
                    SetBulletPosition(transformBullet);
                    FireBullet(transformBullet);
                }
            }
            yield return new WaitForSeconds(_reloadTime);
        }
    }

    private void SetBulletPosition(Transform bulletTransform)
    {
        bulletTransform.SetPositionAndRotation(transform.position + transform.forward * 1.2f, Quaternion.identity);
        bulletTransform.SetActive();
    }

    private void FireBullet(Transform bulletTransform)
    {
        bulletTransform.DOMove(_target.position, _reloadTime);
        bulletTransform.GetComponent<PoolObject>().Destroy(_reloadTime);
    }

    private IEnumerator LookAtTarget()
    {
        while (true)
        {
            if (_movement.IsObjectMove(thisTransform) == false && _target != null)
            {
                thisTransform.LookAt(_target);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void SetTarget(Transform target)
    {
        _target = target;
    }
}
