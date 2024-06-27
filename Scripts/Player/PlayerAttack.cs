using System;
using UnityEngine;

public class PlayerAttack : ObjectPool<PlayerBullet>
{
    [SerializeField] private PlayerBullet _prefab;
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

    public override void Restart()
    {
        foreach(var item in Pool)
        {
            item.Restart();
            item.gameObject.SetActive(false);
        }
    }

    private void Shoot()
    {
        var bullet = GetObject(_prefab);

        bullet.gameObject.SetActive(true);
        bullet.EnemyHit += EnemyHit;
        bullet.transform.position = transform.position;
        Vector2 bulletDirection = transform.right;
        bullet.Direction = bulletDirection;
        bullet.transform.SetParent(Container, false);
        bullet.transform.rotation = Quaternion.identity;
    }

    private void EnemyHit()
    {
        EnemyDead?.Invoke();
    }
}
