using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour, IDamage
{
    [SerializeField] float _currentHP;
    [SerializeField] float _startHP;
    [SerializeField] float _maxHP;
    [SerializeField]HealthBar _healthBarPrefab;
    HealthBar _healthBar;
    public event Action<float> currentHP;
    Renderer _thisRender;
    Color _start_clolor;
    Transform _thisTransform;

    private void Start()
    {
        ResetCharacter();
    }

    public virtual void ResetCharacter()
    {
        _thisTransform = transform;
        _currentHP = _startHP;
        _healthBar = Instantiate(_healthBarPrefab);
        _healthBar._thisTransform.SetParent(_thisTransform);
        _healthBar._thisTransform.position = _thisTransform.position + Vector3.up * 2.0f;
        _healthBar.ResetHealthBar(this, _startHP, _maxHP);
        _thisRender = GetComponent<Renderer>();
        _start_clolor = _thisRender.material.color;
    }
    
    public virtual void KillCharacter()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator FlickerCharacter()
    {
        _thisRender.material.color = Color.clear;
        yield return new WaitForSeconds(0.1f);
        _thisRender.material.color = _start_clolor;
    }

    public void DamageCharacter(float damage)
    {
        _currentHP -= damage;
        StartCoroutine(FlickerCharacter());
        currentHP?.Invoke(_currentHP);
    }
}
