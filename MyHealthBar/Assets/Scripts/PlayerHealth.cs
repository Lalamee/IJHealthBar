using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _delta;

    private float _tempHealth;

    private void Start()
    {
        _tempHealth = _maxHealth / 2;
    }

    public float Cure()
    {
        _tempHealth = Mathf.Clamp(_tempHealth + _delta, _minHealth, _maxHealth);

        return _tempHealth;
    }
    
    public void TakeDamage()
    {
        _tempHealth = Mathf.Clamp(_tempHealth + _delta, _minHealth, _maxHealth);  
    }
}
