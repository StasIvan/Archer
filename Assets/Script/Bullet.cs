using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            other.gameObject.GetComponent<Character>().DamageCharacter(_damage);
        }
        gameObject.SetActive(false);
    }
}
