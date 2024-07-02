using System;
using UnityEngine;

public class PlayerAttack : ObjectPool<PlayerBullet>
{
    [SerializeField] private float _reload;

    private float _nextFireTime;

    public event Action EnemyDead;

    private void Update()
    {
        Shoot();
    }

    public override void Reset()
    {
        foreach (var item in PoolObjects)
        {
            item.Reset();
            item.gameObject.SetActive(false);
        }
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.E) && Time.time >= _nextFireTime)
        {
            var bullet = GetObject();

            bullet.gameObject.SetActive(true);
            bullet.EnemyHit += EnemyHit;
            bullet.transform.position = transform.position + (Vector3)transform.right;
            bullet.Direction = transform.right;

            _nextFireTime = Time.time + _reload;
        }
    }

    private void EnemyHit()
    {
        EnemyDead?.Invoke();
    }
}
