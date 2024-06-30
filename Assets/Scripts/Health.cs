using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _maxHealth;

    private int _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            return;

        _health -= damage;

        ClampHealth();

        if (_health == 0)
            Die();
    }

    public void TakeHeal(int heal)
    {
        if (heal < 0)
            return;

        _health += heal;

        ClampHealth();
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
        Destroy(gameObject);
    }
}
