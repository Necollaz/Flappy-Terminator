using System.Collections;
using UnityEngine;

public class EnemyAttack : ObjectPool<EnemyBullet>
{
    [SerializeField] private float _reload;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Shoot());
        }
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public override void Restart()
    {
        StopAllCoroutines();
        base.Restart();
        _coroutine = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_reload);

        while (enabled)
        {   
            var bullet = GetObject();

            bullet.gameObject.SetActive(true);
            bullet.transform.position = transform.position;
            bullet.Direction = Vector2.left;

            yield return wait;
        }
    }
}