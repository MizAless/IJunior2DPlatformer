using UnityEngine;

public class AreaSpawner : Spawner
{
    [SerializeField] private Area _spawnArea;

    protected override void Spawn()
    {
        Vector3 spawnPosition = new Vector3(_spawnArea.GetRandomXCoordinate(), _spawnArea.YPosition, 0);
        base.Spawn(spawnPosition);
    }
}
