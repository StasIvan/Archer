using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image _fill;
    public Transform thisTransform;

    private void Awake()
    {
        thisTransform = transform;
    }

    public void ResetHealthBar(Character character, float health, float maxHelth)
    {
        SetEvent(character);
        SetMaxHelth(maxHelth);
        SetHealth(health);
    }

    public void SetEvent(Character character)
    {
        character.currentHP += SetHealth;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        _fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHelth(float maxHelth)
    {
        slider.maxValue = maxHelth;
    }
}
