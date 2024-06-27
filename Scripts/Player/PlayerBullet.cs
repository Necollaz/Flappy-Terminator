using System;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public event Action EnemyHit;

    public Vector2 Direction { get; set; }

    public void Restart()
    {
        EnemyHit = null;
        Direction = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            EnemyHit?.Invoke();
            Restart();
            gameObject.SetActive(false);
        }
    }
}
