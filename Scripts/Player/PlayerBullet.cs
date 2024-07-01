using System;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public event Action EnemyHit;

    public void Restart()
    {
        EnemyHit = null;
        Direction = Vector2.zero;
        gameObject.SetActive(false);
    }

    protected override void HandleSpecificCollision(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            EnemyHit?.Invoke();
            Restart();
        }
    }

    private void OnDisable()
    {
        Restart();
    }
}
