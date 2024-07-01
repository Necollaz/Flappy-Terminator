using System;
using UnityEngine;

public class PlayerAttack : ObjectPool<PlayerBullet>
{
    [SerializeField] private float _reload;

    private float _nextFireTime;

    public event Action EnemyDead;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= _nextFireTime)
        {
            Shoot();
            _nextFireTime = Time.time + _reload;
        }
    }

    public void Restart()
    {
        foreach(var item in PoolObjects)
        {
            item.Restart();
            item.gameObject.SetActive(false);
        }
    }

    private void Shoot()
    {
        var bullet = GetObject();

        bullet.gameObject.SetActive(true);
        bullet.EnemyHit += EnemyHit;
        bullet.transform.position = transform.position + (Vector3)transform.right;
        bullet.Direction = transform.right;
    }

    private void EnemyHit()
    {
        EnemyDead?.Invoke();
    }
}
