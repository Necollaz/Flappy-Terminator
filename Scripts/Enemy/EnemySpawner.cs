using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool<Enemy> _enemyPool;
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    private Coroutine _coroutine;

    private void Start()
    {
        StartSpawning();
    }

    public void Reset()
    {
        StopSpawning();
        ClearEnemies();
        _enemyPool.Reset();
        StartSpawning();
    }

    private IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        Enemy enemy = _enemyPool.GetObject();
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private void StopSpawning()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void StartSpawning()
    {
        StartCoroutine(GenerateEnemies());
    }

    private void ClearEnemies()
    {
        foreach (var enemy in _enemyPool.PoolObjects)
        {
            enemy.Reset();
            enemy.gameObject.SetActive(false);
        }
    }
}
