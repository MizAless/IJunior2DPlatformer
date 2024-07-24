using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealDetector : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out HealItem healItem))
        {
            _health.TakeHeal(healItem.HealValue);
            Destroy(collision.gameObject);
        }
    }
}
