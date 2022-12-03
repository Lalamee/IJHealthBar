using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _recoveryRate;
    
    private Slider _slider;
    private Coroutine _changeValueSlider;
    
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _playerHealth.TempHealth;
    }

    public void ControlCoroutine()
    {
        _changeValueSlider = StartCoroutine(ChangeValueSlider());
    }

    private IEnumerator ChangeValueSlider()
    {
        while (_slider.value != _playerHealth.TempHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _playerHealth.TempHealth , _recoveryRate * Time.deltaTime);

            yield return null;
        }
        
        StopCoroutine(_changeValueSlider);
    }
}
