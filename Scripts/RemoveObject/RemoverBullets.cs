using UnityEngine;

public class RemoverBullets : ObjectRemover<Bullet>
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            _pool.PutObject(bullet);
        }
    }
}