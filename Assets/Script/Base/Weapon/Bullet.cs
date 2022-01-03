using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    private PoolObject _poolObject;

    private void Start()
    {
        _poolObject = gameObject.GetComponent<PoolObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var triggerObject = other.gameObject.GetComponent<Character>();
        if (triggerObject != null && other.gameObject.tag != gameObject.tag)
        {
            other.gameObject.GetComponent<Character>().DamageCharacter(_damage);
        }
        if (_poolObject != null)
        {
            _poolObject.Destroy();
        }
        else
        {
            this.SetInactive();
        }
    }


}
