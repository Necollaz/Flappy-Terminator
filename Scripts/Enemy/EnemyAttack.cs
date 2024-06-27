using System.Collections;
using UnityEngine;

public class EnemyAttack : ObjectPool<EnemyBullet>
{
    [SerializeField] private float _delay;
    [SerializeField] private EnemyBullet _prefab;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            var bullet = GetObject(_prefab);

            bullet.gameObject.SetActive(true);
            bullet.transform.position = transform.position;
            bullet.Direction = Vector2.left;

            yield return wait;
        }
    }
}
