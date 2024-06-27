using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool<Enemy>
{
    [SerializeField] private List<Enemy> _prefab;
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(GenerateEnemies());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    public override void Restart()
    {
        base.Restart();
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

        Enemy enemy = GetObject(_prefab);
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
