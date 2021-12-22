using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour, IDamage
{
    [SerializeField] private float _currentHP;
    [SerializeField] private float _startHP;
    [SerializeField] private float _maxHP;
    [SerializeField] private HealthBar _healthBarPrefab;

    public Transform thisTransform;
    public event Action<float> currentHP;

    private HealthBar _healthBar;
    private Renderer _thisRender;
    private Color _start_clolor;
    
    private void Start()
    {
        ResetCharacter();
    }

    public virtual void ResetCharacter()
    {
        thisTransform = transform;
        _currentHP = _startHP;
        _healthBar = Instantiate(_healthBarPrefab);
        _healthBar.thisTransform.SetParent(thisTransform);
        _healthBar.thisTransform.position = thisTransform.position + Vector3.up * 2.0f;
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
