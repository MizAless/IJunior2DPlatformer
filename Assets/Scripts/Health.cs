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
        health -= damage;

        if (health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
