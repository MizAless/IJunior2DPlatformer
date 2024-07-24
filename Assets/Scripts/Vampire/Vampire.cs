using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Vampire : MonoBehaviour
{
    [SerializeField] private float _vampirizeRadius = 3f;
    [SerializeField] private float _vampirizeDuration = 6f;
    [SerializeField] private float _vampirizeCooldown = 2f;
    [SerializeField] private float _damagePerSecond = 15f;
    [SerializeField] private LayerMask enemyMask;

    private Health _health;

    private bool _canVampirize = true;

    public float VampirizeRadius => _vampirizeRadius;
    public float VampirizeCooldown => _vampirizeCooldown;

    public event Action VampirizeStarted;
    public event Action VampirizeEnded;
    public event Action VampirizeCooldownStarted;
    public event Action VampirizeCooldownEnded;
    public event Action<float> CurrentCooldownTimeChanged;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void Vampirize()
    {
        if (_canVampirize == false)
            return;

        StartCoroutine(Vampirizing());
        VampirizeStarted?.Invoke();
    }

    private IEnumerator Vampirizing()
    {
        _canVampirize = false;

        float expiredTime = 0;

        var delay = new WaitForFixedUpdate();

        while (expiredTime < _vampirizeDuration)
        {
            expiredTime += Time.fixedDeltaTime;

            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _vampirizeRadius, enemyMask);

            List<Enemy> enemies = new();

            foreach (var hit in hits)
                if (hit.gameObject.TryGetComponent(out Enemy enemy))
                    enemies.Add(enemy);

            if (enemies.Count > 0)
            {
                Enemy closestEnemy = enemies.OrderBy(enemy => enemy.transform.position.SqrDistance(transform.position)).FirstOrDefault();

                if (closestEnemy.transform.position.IsEnoughClose(transform.position, _vampirizeRadius))
                {
                    float vimpiredDamage = _damagePerSecond * Time.fixedDeltaTime;

                    float dealtDamage = closestEnemy.TakeDamage(vimpiredDamage);
                    _health.TakeHeal(dealtDamage);
                }
            }


            yield return delay;
        }

        VampirizeEnded?.Invoke();
        StartCoroutine(ReloadingVampirize());
    }

    private IEnumerator ReloadingVampirize()
    {
        VampirizeCooldownStarted?.Invoke();

        float currentCooldownTime = 0;

        var delay = new WaitForFixedUpdate();

        while (currentCooldownTime < _vampirizeCooldown)
        {
            currentCooldownTime += Time.fixedDeltaTime;
            CurrentCooldownTimeChanged?.Invoke(currentCooldownTime);
            yield return delay;
        }

        currentCooldownTime = _vampirizeCooldown;
        CurrentCooldownTimeChanged?.Invoke(currentCooldownTime);

        _canVampirize = true;

        VampirizeCooldownEnded?.Invoke();

        print("CanVampirize");
    }
}
