using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void HandleSpecificCollision(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ProcessCollision();
        }
    }
}
