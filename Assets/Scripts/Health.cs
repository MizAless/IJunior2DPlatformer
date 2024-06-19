using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _maxHealth;

    private int health;

    private void Awake()
    {
        health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            return;

        health -= damage;

        health = Mathf.Clamp(health, 0, _maxHealth);

        if (health == 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
