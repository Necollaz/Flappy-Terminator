using System.Collections;
using UnityEngine;

public class EnemyAttack : ObjectPool<EnemyBullet>
{
    [SerializeField] private float _delay;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            var bullet = GetObject();

            bullet.gameObject.SetActive(true);
            bullet.Direction = Vector2.left;
            bullet.transform.position = transform.position;

            yield return new WaitForSeconds(_delay);
        }
    }
}
