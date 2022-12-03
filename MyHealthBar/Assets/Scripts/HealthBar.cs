using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _recoveryRate;
    
    private Slider _slider;
    private Coroutine _changeValueHealth;
    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void ControlCoroutine()
    {
        if (_changeValueHealth != null)
            StopCoroutine(_changeValueHealth);

        if (_slider.value != _playerHealth.Cure())
        {
            _changeValueHealth = StartCoroutine(ChangeHealth());
        }
        else
        {
            StopCoroutine(_changeValueHealth);
        }
    }


    private IEnumerator ChangeHealth()
    {
        while (_slider.value != _playerHealth.Cure())
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _playerHealth.Cure(), _recoveryRate * Time.deltaTime);

            yield return null;
        }
    }
}
