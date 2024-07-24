using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyDamageDealer))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Health _health;

    public event Action<Enemy> Died;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    public float TakeDamage(float damage)
    {
        return _health.TakeDamage(damage);
    }

    private void Die()
    {
        Died?.Invoke(this);
    }
}
