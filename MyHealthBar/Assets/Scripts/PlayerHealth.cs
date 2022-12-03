using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _delta;

    public float TempHealth { get; private set; }

    private void Awake()
    {
        TempHealth = _maxHealth / 2;
    }

    private void ChangeHealth(float delta)
    {
        TempHealth += delta;
    }
    
    public void Cure()
    {
        if(TempHealth < _maxHealth)
            ChangeHealth(_delta);
    }
    
    public void TakeDamage()
    {
        if(TempHealth > _minHealth)
            ChangeHealth(-_delta);
    }
}
