using UnityEngine;

public class RemoverEnemies : ObjectRemover<Enemy>
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _pool.PutObject(enemy);
        }
    }
}