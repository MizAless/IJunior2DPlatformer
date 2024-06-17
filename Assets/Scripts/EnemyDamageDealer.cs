using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }
}
