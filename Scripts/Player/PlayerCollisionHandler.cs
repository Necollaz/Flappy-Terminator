using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action CollisionDetected;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out PlayerBullet bullet))
        {
            if (collision.TryGetComponent(out Enemy enemy) || collision.TryGetComponent(out Ground ground))
            {
                CollisionDetected?.Invoke();
            }
        }
    }
}
