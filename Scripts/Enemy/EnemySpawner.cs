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

    public void Restart()
    {
        StopCoroutine(_coroutine);

        foreach (var enemy in _enemyPool.ActiveObjects)
        {
            enemy.gameObject.SetActive(false);
        }

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
        enemy.Restart();
    }

    private void StartSpawning()
    {
        _coroutine = StartCoroutine(GenerateEnemies());
    }
}
