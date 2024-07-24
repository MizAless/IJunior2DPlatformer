using System;
using System.Collections;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 2f;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private bool isInfinite = true;

    public event Action<GameObject> Spawned;

    private void Start()
    {
        if (isInfinite)
            StartCoroutine(Spawning());
        else
            Spawn();
    }

    private IEnumerator Spawning()
    {
        var spawnDelay = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            Spawn();
            yield return spawnDelay;
        }
    }

    protected abstract void Spawn();

    protected virtual void Spawn(Vector3 spawnPosition)
    {
        GameObject createdObject = Instantiate(_prefab, spawnPosition, Quaternion.identity);
        Spawned?.Invoke(createdObject);
    }
}

