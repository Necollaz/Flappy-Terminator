using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyAttack))]
public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private EnemyAttack _enemyAttack;

    public event Action Dead;

    private void Awake()
    {
        _enemyAttack = GetComponent<EnemyAttack>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.isKinematic = true;
    }

    public void Reset()
    {
        _enemyAttack.Reset();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerBullet _))
        {
            Dead?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
