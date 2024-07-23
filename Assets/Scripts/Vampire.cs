using System;
using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Vampire : MonoBehaviour
{
    [SerializeField] private float _vampirizeRadius = 3f;
    [SerializeField] private float _vampirizeDuration = 6f;
    [SerializeField] private float _vampirizeCooldown = 2f;
    [SerializeField] private float _damagePerSecond = 15f;
    [SerializeField] private EnemyContainer _enemyContainer;

    private Health _health;

    private bool _canVampirize = true;

    private float _currentCooldownTime;

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

            if (_enemyContainer.Enemies.Count > 0)
            {
                Enemy closestEnemy = _enemyContainer.Enemies.OrderBy(enemy => enemy.transform.position.SqrDistance(transform.position)).FirstOrDefault();

                if (closestEnemy.transform.position.IsEnoughClose(transform.position, _vampirizeRadius))
                {
                    float vimpiredDamage = _damagePerSecond * Time.fixedDeltaTime;

                    closestEnemy.TakeDamage(vimpiredDamage);
                    _health.TakeHeal(vimpiredDamage);
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

        _currentCooldownTime = 0;

        var delay = new WaitForFixedUpdate();

        while (_currentCooldownTime < _vampirizeCooldown)
        {
            _currentCooldownTime += Time.fixedDeltaTime;
            CurrentCooldownTimeChanged?.Invoke(_currentCooldownTime);
            yield return delay;
        }

        _currentCooldownTime = _vampirizeCooldown;
        CurrentCooldownTimeChanged?.Invoke(_currentCooldownTime);

        _canVampirize = true;

        VampirizeCooldownEnded?.Invoke();

        print("CanVampirize");
    }
}
