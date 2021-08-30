using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour, IDamage
{
    [SerializeField] float _currentHP;
    [SerializeField] float _startHP;
    public event Action<float> currentHP;
    Renderer _thisRender;
    Color _start_clolor;
    private void Start()
    {
        ResetCharacter();
    }

    public virtual void ResetCharacter()
    {
        _currentHP = _startHP;
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
