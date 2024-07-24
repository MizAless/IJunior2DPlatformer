using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : Spawner
{
    [SerializeField] private List<Transform> _spawnPoints;

    protected override void Spawn()
    {
        foreach (Transform spawnPoint in _spawnPoints)
        {
            base.Spawn(spawnPoint.position);
        }
    }
}
