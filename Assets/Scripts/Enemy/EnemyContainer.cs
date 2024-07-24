using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    private List<Enemy> _enemies;

    public List<Enemy> Enemies => new List<Enemy>(_enemies);

    private void Awake()
    {
        InitEnemies();
    }

    private void InitEnemies()
    {
        _enemies = new();

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out Enemy enemy) && enemy.gameObject.activeInHierarchy)
                _enemies.Add(enemy);
        }

        _enemies.ForEach(enemy => enemy.Died += RemoveEnemy);

        print(_enemies.Count);
    }

    private void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        enemy.Died -= RemoveEnemy;
        print(_enemies.Count);
    }
}
