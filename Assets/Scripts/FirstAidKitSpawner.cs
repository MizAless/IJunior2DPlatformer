using UnityEngine;

public class FirstAidKitSpawner : Spawner
{
    [SerializeField] private float _spawnDelay = 5f;
    [SerializeField] private HealItem _healItemPrefab;
    [SerializeField] private Area _spawnArea;

    private void Awake()
    {
        Init(_spawnDelay, _healItemPrefab.gameObject, _spawnArea);
    }

    private void Start()
    {
        StartCoroutine(Spawning());
    }
}
