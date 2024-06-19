using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 2f;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Area _spawnArea;

    private void Start()
    {
        StartCoroutine(Spawning());
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

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(_spawnArea.GetRandomXCoordinate(), _spawnArea.YPosition, 0);
        Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);
    }
}
