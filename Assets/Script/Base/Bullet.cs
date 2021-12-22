using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(StringContainer.character))
        {
            other.gameObject.GetComponent<Character>().DamageCharacter(_damage);
        }
        gameObject.SetActive(false);
    }
}
