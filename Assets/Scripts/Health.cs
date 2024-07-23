using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float _maxHealth;

    private float _health;

    public event Action<float, float> Changed;
    public event Action Died;

    private void Awake()
    {
        _health = _maxHealth;
        Changed?.Invoke(_health, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        _health -= damage;

        ClampHealth();
        Changed?.Invoke(_health, _maxHealth);

        if (_health == 0)
            Die();
    }

    public void TakeHeal(float heal)
    {
        if (heal < 0)
            return;

        _health += heal;

        ClampHealth();
        Changed?.Invoke(_health, _maxHealth);
    }

    private void ClampHealth()
    {
        _health = Mathf.Clamp(_health, 0, _maxHealth);

        if (gameObject.TryGetComponent<Player>(out _))
            ShowDebugInfo();
    }

    private void ShowDebugInfo()
    {
        print($"Current health: {_health}");
    }

    private void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}
