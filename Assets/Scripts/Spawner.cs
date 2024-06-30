using System.Collections;
using UnityEngine;

abstract public class Spawner : MonoBehaviour
{
    protected float SpawnDelay = 2f;
    protected GameObject Prefab;
    protected Area SpawnArea;

    protected void Init(float spawnDelay, GameObject prefab, Area spawnArea)
    {
        SpawnDelay = spawnDelay;
        Prefab = prefab;
        SpawnArea = spawnArea;
    }

    protected IEnumerator Spawning()
    {
        var spawnDelay = new WaitForSeconds(SpawnDelay);

        while (enabled)
        {
            Spawn();
            yield return spawnDelay;
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(SpawnArea.GetRandomXCoordinate(), SpawnArea.YPosition, 0);
        Instantiate(Prefab, spawnPosition, Quaternion.identity);
    }
}

